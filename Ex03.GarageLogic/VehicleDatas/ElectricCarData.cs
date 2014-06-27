// -----------------------------------------------------------------------
// <copyright file="ElectricCarData.cs" company="Hewlett-Packard">
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
    public class ElectricCarData : CarData
    {
        private const float k_MaxBatteryTime = 2.5f;
        private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.ElectricCar;
        
        public ElectricCarData(
                             string i_ModelName, 
                             string i_LicenseNum, 
                             string i_WheelsManufacturer,
                             Car.eCarColor i_CarColor, 
                             Car.eNumOfDoors i_NumOfDoors)
                             : base(
                             i_ModelName, 
                             i_LicenseNum,
                             new ElectricBattery(k_MaxBatteryTime),
                             i_WheelsManufacturer,
                             k_TypeOfVehicle, 
                             i_CarColor, 
                             i_NumOfDoors)
        {
        }

        public float MaxBatteryTime
        {
            get { return k_MaxBatteryTime; }
        }
    }
}
