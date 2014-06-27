// -----------------------------------------------------------------------
// <copyright file="ElectricMotorCycleData.cs" company="Hewlett-Packard">
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
    public class ElectricMotorCycleData : MotorCycleData
    {
          private const float k_MaxBatteryTime = 2.2f;
          private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.ElectricMotorcycle;

        public ElectricMotorCycleData(
                                     string i_ModelName, 
                                     string i_LicenseNum,
                                     string i_WheelsManufacturer,
                                     MotorCycle.eMotorCycleLicenseType i_LicenseType, 
                                     int i_EngineCapacity)
                                    : base(
                                    i_ModelName,
                                    i_LicenseNum,
                                    new ElectricBattery(k_MaxBatteryTime),
                                    i_WheelsManufacturer,
                                    k_TypeOfVehicle,  
                                    i_LicenseType,
                                    i_EngineCapacity)
        {
        }

        public float MaxBatteryTime
        {
            get { return k_MaxBatteryTime; }
        }
    }
}
