// -----------------------------------------------------------------------
// <copyright file="GasCarData.cs" company="Hewlett-Packard">
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
    public class GasCarData : CarData
    {
        private const float k_GasTankCapacity = 55;
        private const GasTank.eGasType k_GasType = GasTank.eGasType.Octan98;
        private const Vehicle.eTypeOfVehicle k_TypeOfVehicle = Vehicle.eTypeOfVehicle.GasCar;

        public GasCarData(
                          string i_ModelName,
                          string i_LicenseNum,
                          string i_WheelsManufacturer, 
                          Car.eCarColor i_CarColor, 
                          Car.eNumOfDoors i_NumOfDoors)
                         : base(
                         i_ModelName, 
                         i_LicenseNum, 
                         new GasTank(k_GasTankCapacity, k_GasType),
                         i_WheelsManufacturer,
                         k_TypeOfVehicle,
                         i_CarColor, 
                         i_NumOfDoors)
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
    }
}
