// -----------------------------------------------------------------------
// <copyright file="GasMotorCycleData.cs" company="Hewlett-Packard">
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
    public class GasMotorCycleData : MotorCycleData
    {
        private const float k_GasTankCapacity = 7;
        private const GasTank.eGasType k_GasType = GasTank.eGasType.Octan95;
        private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.GasMotorcycle;

        public GasMotorCycleData(
                                string i_ModelName, 
                                string i_LicenseNum,
                                string i_WheelsManufacturer,
                                MotorCycle.eMotorCycleLicenseType i_LicenseType,
                                int i_EngineCapacity)
                                : base(
                                i_ModelName, 
                                i_LicenseNum, 
                                new GasTank(k_GasTankCapacity, k_GasType), 
                                i_WheelsManufacturer, 
                                k_TypeOfVehicle, 
                                i_LicenseType, 
                                i_EngineCapacity)
        {
        }

        public float GasTankCapacity
        {
            get { return k_GasTankCapacity; }
        }

        public GasTank.eGasType GasType
        {
            get { return k_GasType; }
        }

        public void AddFuel(float i_FuelToAdd, GasTank.eGasType i_GasType)
        {
            (EnergySource as GasTank).AddFuel(i_FuelToAdd, i_GasType);
        }
    }
}
