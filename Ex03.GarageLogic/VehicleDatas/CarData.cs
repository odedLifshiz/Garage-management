// -----------------------------------------------------------------------
// <copyright file="CarData.cs" company="Hewlett-Packard">
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
    public abstract class CarData : VehicleData
    {
        private const int k_CarWheelsMaxAirPressure = 28;
        private const int k_CarNumberOfWheels = 4;
        private Car.eCarColor m_CarColor;
        private Car.eNumOfDoors m_NumOfDoors;

        public CarData(
                       string i_ModelName,
                       string i_LicenseNum, 
                       EnergySource i_EnergySource,
                       string i_WheelsManufacturer,
                       Vehicle.eTypeOfVehicle i_TypeOfVehicle, 
                       Car.eCarColor i_CarColor,
                       Car.eNumOfDoors i_NumOfDoors)
                       : base(
                       i_ModelName, 
                       i_LicenseNum,
                       i_EnergySource,
                       k_CarNumberOfWheels,
                       i_WheelsManufacturer,
                       k_CarWheelsMaxAirPressure,
                       i_TypeOfVehicle)
        {
            m_CarColor = i_CarColor;
            m_NumOfDoors = i_NumOfDoors;
        }

        public static new List<VehicleParameter> GetRequiredParameters()
        {
            List<VehicleParameter> parameters = VehicleData.GetRequiredParameters();
            parameters.Add(new VehicleParameter(typeof(Car.eCarColor), "color of car"));
            parameters.Add(new VehicleParameter(typeof(Car.eNumOfDoors), "number of doors"));

            return parameters;
        }

        public override string ToString()
        {
            string carData = string.Format("{0}Car Color: {1}{0}Number Of Doors: {2}{0}", Environment.NewLine, m_CarColor, m_NumOfDoors);

            return base.ToString() + carData;
        }
    }
}
