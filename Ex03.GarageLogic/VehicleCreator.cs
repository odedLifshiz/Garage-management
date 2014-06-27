// -----------------------------------------------------------------------
// <copyright file="VehicleCreator.cs" company="Hewlett-Packard">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class VehicleCreator
    {
        public static Vehicle MakeVehicle(Vehicle.eTypeOfVehicle i_TypeOfVehicle, VehicleData i_VehicleData)
        {
            Vehicle newVehicle = null;

            switch (i_TypeOfVehicle)
            {
                case Vehicle.eTypeOfVehicle.GasCar:
                    newVehicle = new GasCar(i_VehicleData as GasCarData);
                    break;
                case Vehicle.eTypeOfVehicle.ElectricCar:
                    newVehicle = new ElectricCar(i_VehicleData as ElectricCarData);
                    break;
                case Vehicle.eTypeOfVehicle.ElectricMotorcycle:
                    newVehicle = new ElectricMotorCycle(i_VehicleData as ElectricMotorCycleData);
                    break;
                case Vehicle.eTypeOfVehicle.GasMotorcycle:
                    newVehicle = new GasMotorCycle(i_VehicleData as GasMotorCycleData);
                    break;
                case Vehicle.eTypeOfVehicle.GasTruck:
                    newVehicle = new GasTruck(i_VehicleData as GasTruckData);
                    break;
            }

            return newVehicle;
        }
    }
}
