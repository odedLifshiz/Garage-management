// -----------------------------------------------------------------------
// <copyright file="Garage.cs" company="Hewlett-Packard">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

        public enum eVehicleStateInGarage
        {
            WorkInProgress,
            WorkComplete,
            Paid
        }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
        public class Garage
        {
            private readonly Dictionary<string, GarageVehicle> r_DictOfGarageVehicles;

            public Garage()
            {
                r_DictOfGarageVehicles = new Dictionary<string, GarageVehicle>();
            }

            public bool AddVehicleToGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNum)
            {
                if (i_Vehicle == null)
                {
                    throw new ArgumentNullException();
                }

                bool vehicleExistsInGarage = r_DictOfGarageVehicles.ContainsKey(i_Vehicle.VehicleData.LicenseNumber);
                GarageVehicle vehicleInGarage;

                if (vehicleExistsInGarage)
                {
                    ChangeExistingVehicleState(i_Vehicle.VehicleData.LicenseNumber, eVehicleStateInGarage.WorkInProgress);
                }
                else
                {
                    vehicleInGarage = new GarageVehicle(i_Vehicle, i_OwnerName, i_OwnerPhoneNum);
                    r_DictOfGarageVehicles.Add(i_Vehicle.VehicleData.LicenseNumber, vehicleInGarage);
                }

                return vehicleExistsInGarage;
            }
          
            public List<string> GetLicenseNumbers()
            {
                List<string> licenseNums = new List<string>();
                foreach (string licenseNum in r_DictOfGarageVehicles.Keys)
                {
                    licenseNums.Add(licenseNum);
                }

                return licenseNums;
            }

            public List<string> GetLicenseNumbers(eVehicleStateInGarage i_StateInGarage)
            {
                List<string> licenseNumbers = new List<string>();
                foreach (GarageVehicle vehicleInGarage in r_DictOfGarageVehicles.Values)
                {
                    if (vehicleInGarage.VehicleStateInGarage == i_StateInGarage)
                    {
                        licenseNumbers.Add(vehicleInGarage.Vehicle.VehicleData.LicenseNumber);
                    }
                }

                return licenseNumbers;
            }

            public void ChangeExistingVehicleState(string i_LicenseNum, eVehicleStateInGarage i_NewVehicleState)
            {
                GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
                if (vehicleInGarage == null)
                {
                    throw new VehicleNotFoundException(i_LicenseNum);
                }

                vehicleInGarage.VehicleStateInGarage = i_NewVehicleState;
            }

            public void InflateVehicleWheelsToMax(string i_LicenseNum)
            {
                GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
                if (vehicleInGarage == null)
                {
                    throw new VehicleNotFoundException(i_LicenseNum);
                }

                foreach (Wheel wheel in vehicleInGarage.Vehicle.VehicleData.Wheels)
                {
                    wheel.inflateWheelToMax();
                }      
            }

            public void AddGasToVehicle(string i_LicenseNum, GasTank.eGasType i_GasType, float i_GasAmountToAdd)
            {
                GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
                if (vehicleInGarage == null)
                {
                    throw new VehicleNotFoundException(i_LicenseNum);
                }

                if (!(vehicleInGarage.Vehicle.VehicleData.EnergySource is GasTank))
                {
                    throw new IncompatibleEnergyType();
                }

                (vehicleInGarage.Vehicle.VehicleData.EnergySource as GasTank).AddFuel(i_GasAmountToAdd, i_GasType);
            }

            public void ChargeElectricVehicle(string i_LicenseNum, float i_ChargeAmount)
            {
                GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
                if (vehicleInGarage == null)
                {
                    throw new VehicleNotFoundException(i_LicenseNum);
                }

                if (!(vehicleInGarage.Vehicle.VehicleData.EnergySource is ElectricBattery))
                {
                    throw new IncompatibleEnergyType();
                }

                (vehicleInGarage.Vehicle.VehicleData.EnergySource as ElectricBattery).ChargeBattery(i_ChargeAmount);
            }

            public string GetVehicleData(string i_LicenseNum)
            {
                GarageVehicle vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);
                if (vehicleInGarage == null)
                {
                    throw new VehicleNotFoundException(i_LicenseNum);
                }

                return vehicleInGarage.ToString();
            }
           
            private GarageVehicle getVehicleFromDictionary(string i_LicenseNum)
            {
                GarageVehicle garageVehicle;
                bool vehicleExists = r_DictOfGarageVehicles.TryGetValue(i_LicenseNum, out garageVehicle);
                if (!vehicleExists)
                {
                    garageVehicle = null;
                }

                return garageVehicle;
            }

            private class GarageVehicle
            {
                private string m_OwnerName;
                private string m_OwnerPhoneNumber;
                private eVehicleStateInGarage m_VehicleStateInGarage;
                private Vehicle m_Vehicle;

                public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
                {
                    m_OwnerName = i_OwnerName;
                    m_OwnerPhoneNumber = i_OwnerPhoneNumber;
                    m_Vehicle = i_Vehicle;
                    m_VehicleStateInGarage = eVehicleStateInGarage.WorkInProgress;
                }

                public eVehicleStateInGarage VehicleStateInGarage
                {
                    get { return m_VehicleStateInGarage; }
                    set { m_VehicleStateInGarage = value; }
                }

                public Vehicle Vehicle
                {
                    get { return m_Vehicle; }
                }

                public string OwnerName
                {
                    get { return m_OwnerName; }
                }

                public string OwnerPhoneNumber
                {
                    get { return m_OwnerPhoneNumber; }
                }

                public override string ToString()
                {
                    string vehicleDetails = String.Format(
                        "Owner Name: {1}{0}Owner Phone: {2}{0}Status in garage: {3}{0}",
                        Environment.NewLine,
                        OwnerName,
                        OwnerPhoneNumber,
                        VehicleStateInGarage);

                    return Vehicle.ToString() + vehicleDetails;
                }
            }
        }
}
