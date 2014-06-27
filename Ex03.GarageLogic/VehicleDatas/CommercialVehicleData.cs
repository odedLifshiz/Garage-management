// -----------------------------------------------------------------------
// <copyright file="CommercialVehicleData.cs" company="Hewlett-Packard">
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
    public class CommercialVehicleData : VehicleData
    {
        private readonly float r_Volume;
        private bool m_IsTransporingHazardMaterials;

        public CommercialVehicleData(
            string i_ModelName, 
            string i_LicenseNum,
            EnergySource i_EnergyType,
            int i_NumOfWheels,
            string i_WheelsManufacturer, 
            float i_WheelsMaxAirPressure,
            Vehicle.eTypeOfVehicle i_TypeOfVehicle,
            float i_Volume,
            bool i_IsTransportingHazardMaterials)
            : base(i_ModelName, i_LicenseNum, i_EnergyType, i_NumOfWheels, i_WheelsManufacturer, i_WheelsMaxAirPressure, i_TypeOfVehicle)
        {
            r_Volume = i_Volume;
            m_IsTransporingHazardMaterials = i_IsTransportingHazardMaterials;
        }

        public static new List<VehicleParameter> GetRequiredParameters()
        {
            List<VehicleParameter> parameters = VehicleData.GetRequiredParameters();
            parameters.Add(new VehicleParameter(typeof(float), "Maximum volume"));
            parameters.Add(new VehicleParameter(typeof(bool), "vehicle carrying hazard materials"));

            return parameters;
        }

        public override string ToString()
        {
            string commercialVehicleData = string.Format(
                               "{0}Max volume allowed: {1}{0}" +
                               "Is transporing hazardous materials: {2}{0}",
                               Environment.NewLine,
                               r_Volume,
                               m_IsTransporingHazardMaterials);
            
            return base.ToString() + commercialVehicleData;
        }
    }
}
