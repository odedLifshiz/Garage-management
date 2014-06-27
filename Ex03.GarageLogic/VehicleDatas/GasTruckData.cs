// -----------------------------------------------------------------------
// <copyright file="GasTruckData.cs" company="Hewlett-Packard">
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
    public class GasTruckData : CommercialVehicleData
    {
        private const int k_MaxAirPressure = 27;
        private const int k_NumOfWheels = 8;
        private const GasTank.eGasType k_GasType = GasTank.eGasType.Octan96;
        private const int k_GasTruckMaxFuelCapacity = 150;
        private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.GasTruck;

        public GasTruckData(
                            string i_ModelName,
                            string i_LicenseNum, 
                            string i_WheelsManufacturer,
                            float i_Volume,
                            bool i_IsTransportingHazardMaterials)
                           : base(
                           i_ModelName, 
                           i_LicenseNum,
                           new GasTank(k_GasTruckMaxFuelCapacity, k_GasType),
                           k_NumOfWheels, 
                           i_WheelsManufacturer,
                           k_MaxAirPressure, 
                           k_TypeOfVehicle, 
                           i_Volume,
                           i_IsTransportingHazardMaterials) 
        {
        }
    }
}
