// -----------------------------------------------------------------------
// <copyright file="MotorCycleData.cs" company="Hewlett-Packard">
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
    public class MotorCycleData : VehicleData
    {
        private const int k_MotorcycleWheelsMaxAirPressure = 31;
        private const int k_MotorCycleNumOfWheels = 2;
        private MotorCycle.eMotorCycleLicenseType m_LicenseType;
        private int m_EngineVolume;

        public MotorCycleData(
                             string i_ModelName, 
                             string i_LicenseNum,
                             EnergySource i_EnergySource, 
                             string i_WheelsManufacturer,
                             Vehicle.eTypeOfVehicle i_TypeOfVehicle,
                             MotorCycle.eMotorCycleLicenseType i_LicenseType,
                            int i_EngineCapacity)
                            : base(
                                  i_ModelName, 
                                  i_LicenseNum,
                                  i_EnergySource,
                                  k_MotorCycleNumOfWheels,
                                  i_WheelsManufacturer,
                                  k_MotorcycleWheelsMaxAirPressure,
                                  i_TypeOfVehicle)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineCapacity;
        }

        public static new List<VehicleParameter> GetRequiredParameters()
        {
            List<VehicleParameter> parameters = VehicleData.GetRequiredParameters();
            parameters.Add(new VehicleParameter(typeof(MotorCycle.eMotorCycleLicenseType), "license Type"));
            parameters.Add(new VehicleParameter(typeof(int), "engine capacity"));

            return parameters;
        }

        public MotorCycle.eMotorCycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineCapacity
        {
            get { return m_EngineVolume; }
        }

        public override string ToString()
        {
            string motorCycleData = string.Format(
                                    "{0}License type: {1}{0}Engine Volume: {2}{0}",
                                     Environment.NewLine, 
                                     m_LicenseType,
                                     m_EngineVolume);
            return base.ToString() + motorCycleData;
        }
    }
}
