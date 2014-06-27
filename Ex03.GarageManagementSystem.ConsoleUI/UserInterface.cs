// -----------------------------------------------------------------------
// <copyright file="UserInterface.cs" company="Hewlett-Packard">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Ex03.GarageLogic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UserInterface
    {
        private const string k_MainMenuText =
     @"Please choose from the following options (1-9):
        1. Add a new vehicle to garage.
        2. Display license plate numbers for all vehicles in the garage.
        3. Display license numbers for vehicles filtered by garage status.
        4. Modify a vehicle's status.
        5. Inflate a vehicle's wheels to maximum.
        6. Refuel a gasoline-powered vehicle.
        7. Charge an electric vehicle.
        8. Display full details of a vehicle.
        9. Quit.
        ";

        private static Garage s_Garage = new Garage();
        private static bool s_ExitProgram = false;

        public enum eMenuOption
        {
            AddVehicle,
            DisplayLicenseNumbers,
            DisplayFilteredLicenseNumbers,
            ModifyVehicleStatus,
            InflateVehicleWheels,
            RefuelGasolineVehicle,
            ChargeElectricVehicle,
            DisplayVehicleDetails,
            QuitProgram
        }

        public static void Run()
        {
            eMenuOption menuOptionEnum;
            int userMenuSelection;
            string inputAsString;
            while (!s_ExitProgram)
            {
                try
                {
                    Console.Clear();
                    showInitialMenu();
                    inputAsString = Console.ReadLine();
                    userMenuSelection = parseUserSelection(inputAsString, Enum.GetNames(typeof(eMenuOption)).Length);
                    menuOptionEnum = (eMenuOption)Enum.GetValues(typeof(eMenuOption)).GetValue(userMenuSelection - 1);
                    handleMenuSelection(menuOptionEnum);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: bad input format.");
                }
                catch (ValueOutOfRangeException exception)
                {
                    Console.WriteLine(
                                     String.Format(
                                     "Error: input must in the range of {0}-{1}.",
                                      exception.MinValue,
                                      exception.MaxValue));
                }
                catch (VehicleNotFoundException exception)
                {
                    Console.WriteLine(string.Format(
                                      "Error: vehicle with license number: {0} was not found.",
                                      exception.LicenseNum));
                }
                catch (IncompatibleVehicleDataException exception)
                {
                    Console.WriteLine(string.Format(
                                     "Error: Could not create {1}{0}. Invalid data.",
                                      Environment.NewLine,
                                      exception.VehicleType));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Error: invalid argument.");
                }
                catch (IncompatibleEnergyType)
                {
                    Console.WriteLine("Error: trying to add energy with an invalid energy type.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: terminating program.");
                    s_ExitProgram = true;
                }
             
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private static void handleMenuSelection(eMenuOption i_MenuOption)
        {
            switch (i_MenuOption)
            {
                case eMenuOption.AddVehicle:
                    addVehicleToGarage();
                    break;
                case eMenuOption.DisplayLicenseNumbers:
                    displayAllLicenseNumbers();
                    break;
                case eMenuOption.DisplayFilteredLicenseNumbers:
                    displayFilteredLicenseNumbers();
                    break;
                case eMenuOption.ModifyVehicleStatus:
                    modifyVehicleState();
                    break;
                case eMenuOption.InflateVehicleWheels:
                    inflateVehicleWheels();
                    break;
                case eMenuOption.RefuelGasolineVehicle:
                    addGasToVehicle();
                    break;
                case eMenuOption.ChargeElectricVehicle:
                    chargeElectricVehicle();
                    break;
                case eMenuOption.DisplayVehicleDetails:
                    displayVehicleDetails();
                    break;
                case eMenuOption.QuitProgram:
                    exitProgram();
                    break;
                default:
                    break;
            }
        }

        private static void addVehicleToGarage()
        {
            string ownerName;
            string ownerPhone;
            bool vehicleIsAlreadyInGarage;
            Vehicle vehicleToAdd;

            vehicleToAdd = getVehicleFromUser();
            Console.WriteLine("Please enter owner name");
            ownerName = Console.ReadLine();
            Console.WriteLine("Please enter owner phone");
            ownerPhone = Console.ReadLine();
            vehicleIsAlreadyInGarage = s_Garage.AddVehicleToGarage(
                                                                 vehicleToAdd,
                                                                 ownerName, 
                                                                 ownerPhone);

            if (vehicleIsAlreadyInGarage)
            {
                Console.WriteLine(string.Format(
                     "An identical vehicle is already in the garage,{0}"
                    + "Changing status to in-progress",
                    Environment.NewLine));
            }
            else
            {
                Console.WriteLine("Vehicle was added succesfully");
            }
        }

        private static void displayAllLicenseNumbers()
        {
            List<string> licenses = s_Garage.GetLicenseNumbers();
            if (licenses.Count > 0)
            {
                foreach (string curLicense in licenses)
                {
                    Console.WriteLine(curLicense);
                }
            }
            else
            {
                Console.WriteLine("The garage is empty");
            }         
        }
      
        private static void displayFilteredLicenseNumbers()
        {
            eVehicleStateInGarage filter = (eVehicleStateInGarage) getUserChoiceFromEnumValues(typeof(eVehicleStateInGarage));
            List<string> licenses = s_Garage.GetLicenseNumbers(filter);
            foreach (string curLicense in licenses)
            {
                Console.WriteLine(curLicense);
            }
        }

        private static void modifyVehicleState()
        {
            Console.WriteLine("Please enter licence number");
            string license = Console.ReadLine();
            eVehicleStateInGarage newVehicleState = (eVehicleStateInGarage)getUserChoiceFromEnumValues(typeof(eVehicleStateInGarage));
           s_Garage.ChangeExistingVehicleState(license, newVehicleState);
            Console.WriteLine("Vehicle state changed successfully");
        }

        private static void inflateVehicleWheels()
        {
            Console.WriteLine("Please enter licence number");
            string license = Console.ReadLine();
            s_Garage.InflateVehicleWheelsToMax(license);
        }
        
        private static void addGasToVehicle()
        {
            float gasAmountToAdd;
            Console.WriteLine("Please enter licence number: ");
            string license = Console.ReadLine();
            GasTank.eGasType gasType = (GasTank.eGasType)getUserChoiceFromEnumValues(typeof(GasTank.eGasType));
            Console.WriteLine("Please enter how many litres of gas to add: ");
            string gasAmountAsString = Console.ReadLine();
            if (!float.TryParse(gasAmountAsString, out gasAmountToAdd))
            {
                throw new FormatException();
            }

            s_Garage.AddGasToVehicle(license, gasType, gasAmountToAdd);
            Console.WriteLine("Added gas successfully");
        }

        private static void chargeElectricVehicle()
        {
            float chargeAmount;
            Console.WriteLine("Please enter license number: ");
            string licenseNumber = Console.ReadLine();
             Console.WriteLine("Please enter how much to charge: ");
            string chargeAmountAsString = Console.ReadLine();
            if (!float.TryParse(chargeAmountAsString, out chargeAmount))
            {
                throw new FormatException();
            }

            s_Garage.ChargeElectricVehicle(licenseNumber, chargeAmount);
            Console.WriteLine("Charged successfully");
        }
        
        private static void displayVehicleDetails()
        {
            Console.WriteLine("Please enter license number: ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine(s_Garage.GetVehicleData(licenseNumber));
        }

        private static void exitProgram()
        {
            Console.WriteLine("Goodbye");
            s_ExitProgram = true;
        }

        private static Vehicle getVehicleFromUser()
        {
            Vehicle createdVehicle = null;
            VehicleData createdVehicleData = null;
            List<object> userEnteredParameters;
            Vehicle.eTypeOfVehicle typeOfVehicleToAdd = (Vehicle.eTypeOfVehicle)getUserChoiceFromEnumValues(typeof(Vehicle.eTypeOfVehicle));

            switch (typeOfVehicleToAdd)
            {
                case Vehicle.eTypeOfVehicle.GasCar:
                    userEnteredParameters = getParametersFromUser(GasCarData.GetRequiredParameters());
                    createdVehicleData = new GasCarData(
                                                       (string)userEnteredParameters[0], 
                                                       (string)userEnteredParameters[1],
                                                       (string)userEnteredParameters[2],
                                                       (Car.eCarColor)userEnteredParameters[3],
                                                       (Car.eNumOfDoors)userEnteredParameters[4]);
                    break;
                case Vehicle.eTypeOfVehicle.ElectricCar:
                    userEnteredParameters = getParametersFromUser(ElectricCarData.GetRequiredParameters());
                    createdVehicleData = new ElectricCarData(
                                                            (string)userEnteredParameters[0],
                                                            (string)userEnteredParameters[1],
                                                            (string)userEnteredParameters[2], 
                                                            (Car.eCarColor)userEnteredParameters[3],
                                                            (Car.eNumOfDoors)userEnteredParameters[4]);
                    break;
                case Vehicle.eTypeOfVehicle.ElectricMotorcycle:
                    userEnteredParameters = getParametersFromUser(ElectricMotorCycleData.GetRequiredParameters());
                    createdVehicleData = new ElectricMotorCycleData(
                                                                   (string)userEnteredParameters[0], 
                                                                   (string)userEnteredParameters[1],
                                                                   (string)userEnteredParameters[2], 
                                                                   (MotorCycle.eMotorCycleLicenseType)userEnteredParameters[3],
                                                                   (int)userEnteredParameters[4]);
                    break;
                case Vehicle.eTypeOfVehicle.GasMotorcycle:
                    userEnteredParameters = getParametersFromUser(GasMotorCycleData.GetRequiredParameters());
                    createdVehicleData = new GasMotorCycleData(
                                                              (string)userEnteredParameters[0],
                                                              (string)userEnteredParameters[1],
                                                              (string)userEnteredParameters[2],
                                                              (MotorCycle.eMotorCycleLicenseType)userEnteredParameters[3],
                                                              (int)userEnteredParameters[4]);
                    break;
                case Vehicle.eTypeOfVehicle.GasTruck:
                    userEnteredParameters = getParametersFromUser(GasTruckData.GetRequiredParameters());
                    createdVehicleData = new GasTruckData(
                                                         (string)userEnteredParameters[0],
                                                         (string)userEnteredParameters[1],
                                                         (string)userEnteredParameters[2], 
                                                         (float)userEnteredParameters[3], 
                                                         (bool)userEnteredParameters[4]);
                    break;
                default:
                    break;
            }

            createdVehicle = VehicleCreator.MakeVehicle(typeOfVehicleToAdd, createdVehicleData);

            return createdVehicle;
        }

        private static List<object> getParametersFromUser(List<VehicleParameter> i_VehicleRequiredParamteres)
        {
            List<object> userEnteredParameters = new List<object>();
            string message;
            string userInputAsString;

            foreach (VehicleParameter currentParam in i_VehicleRequiredParamteres)
            {
                if (currentParam.Type == typeof(bool))
                {
                    message = string.Format(
                                           "Please choose {1}:{0}Enter 1 for 'yes' or 2 for 'no'.",
                                            Environment.NewLine,
                                            currentParam.Description);
                    Console.WriteLine(message);
                    userInputAsString = Console.ReadLine();
                    if (userInputAsString.Equals("1"))
                    {
                        userEnteredParameters.Add(true);
                    }
                    else if (userInputAsString.Equals("2"))
                    {
                        userEnteredParameters.Add(false);
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                else if (currentParam.Type == typeof(int))
                {
                    int value;
                    message = string.Format("Please enter {0} (an integer number):", currentParam.Description);
                    Console.WriteLine(message);
                    userInputAsString = Console.ReadLine();
                    bool isNumber = int.TryParse(userInputAsString, out value);
                    if (isNumber)
                    {
                        userEnteredParameters.Add(value);
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                else if (currentParam.Type == typeof(float))
                {
                    float value;
                    message = string.Format("Please enter {0} (a number):", currentParam.Description);
                    Console.WriteLine(message);
                    userInputAsString = Console.ReadLine();
                    bool isFloat = float.TryParse(userInputAsString, out value);
                    if (isFloat)
                    {
                        userEnteredParameters.Add(value);
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                
                else if (currentParam.Type == typeof(string))
                {
                    message = string.Format("Please enter {0}: ", currentParam.Description);
                    Console.WriteLine(message);
                    userInputAsString = Console.ReadLine();
                    userEnteredParameters.Add(userInputAsString);
                }
                else if (currentParam.Type.IsEnum)
                {
                    Console.WriteLine(
                                    string.Format(
                                    "Please enter {0}.",
                                    currentParam.Description));
                    userEnteredParameters.Add(getUserChoiceFromEnumValues(currentParam.Type));
                }
            }

            return userEnteredParameters;
        }

        private static void displayAllVehicleTypes()
        {
            int index = 1;
            foreach (string enumName in Enum.GetNames(typeof(Vehicle.eTypeOfVehicle)))
            {
                Console.Write("{0}. {1}", index, enumName);
                index++;
            }
        }

        private static void showInitialMenu()
        {
            Console.WriteLine(k_MainMenuText);
        }

        private static int parseUserSelection(string i_InputAsString, int i_RangeOfCurrentEnum)
        {
            int userSelection;
            if (!int.TryParse(i_InputAsString, out userSelection))
            {
                {
                    throw new FormatException();
                }
            }

            if (userSelection < 1 || userSelection > i_RangeOfCurrentEnum)
            {
                throw new ValueOutOfRangeException(1, i_RangeOfCurrentEnum);
            }

            return userSelection;
        }

        private static object getUserChoiceFromEnumValues(Type i_Enum)
        {
            object enumValueToReturn = null;

            if (!i_Enum.IsEnum)
            {
                throw new ArgumentException();
            }

            Console.WriteLine("Choose one of the following: ");
            int currentValueIndex = 1;

            foreach (object enumValue in Enum.GetValues(i_Enum))
            {
                Console.WriteLine(string.Format("{0}- {1}", currentValueIndex, enumValue));
                currentValueIndex++;
            }

            string textualIndexOfEnumValue = Console.ReadLine();
            int userSuppliedIndexOfEnumValue;
            bool isNumber = int.TryParse(textualIndexOfEnumValue, out userSuppliedIndexOfEnumValue);

            if (!isNumber)
            {
                throw new FormatException();
            }

            if (userSuppliedIndexOfEnumValue < 1 || userSuppliedIndexOfEnumValue > currentValueIndex - 1)
            {
                throw new ValueOutOfRangeException(1, currentValueIndex - 1);
            }

            currentValueIndex = 1;
            foreach (object enumValue in Enum.GetValues(i_Enum))
            {
                if (userSuppliedIndexOfEnumValue == currentValueIndex)
                {
                    enumValueToReturn = enumValue;
                    break;
                }

                currentValueIndex++;
            }

            return enumValueToReturn;
        } 
    }
}
