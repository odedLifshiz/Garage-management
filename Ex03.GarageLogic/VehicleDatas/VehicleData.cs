// -----------------------------------------------------------------------
// <copyright file="VehicleData.cs" company="Hewlett-Packard">
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
    public class VehicleData
    {
        private readonly string m_ModelName;
        private readonly string m_LicenseNum;
        private readonly List<Wheel> m_Wheels;
        private readonly Vehicle.eTypeOfVehicle r_TypeOfVehicle;
        private EnergySource m_EnergySource;
        private int m_NumOfWheels;
     
        public VehicleData(
                           string i_ModelName,
                           string i_LicenseNum, 
                           EnergySource i_EnergyType,
                           int i_NumOfWheels,
                           string i_WheelsManufacturer, 
                           float i_WheelsMaxAirPressure, 
                           Vehicle.eTypeOfVehicle i_TypeOfVehicle)
        {
            m_ModelName = i_ModelName;
            m_LicenseNum = i_LicenseNum;
            m_EnergySource = i_EnergyType;
            m_NumOfWheels = i_NumOfWheels;
            r_TypeOfVehicle = i_TypeOfVehicle;
            m_Wheels = new List<Wheel>();
            createVehicleWheels(i_NumOfWheels, i_WheelsManufacturer, i_WheelsMaxAirPressure);
        }

        private void createVehicleWheels(int i_NumOfWheels, string i_WheelsManufacturer, float i_WheelsMaxAirPressure)
        {
            for (int currWheel = 0; currWheel < i_NumOfWheels; currWheel++)
            {
                m_Wheels.Add(new Wheel(i_WheelsManufacturer, i_WheelsMaxAirPressure));
            }
        }

        public string ModelName
        {
            get { return ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNum; }
        }

        public EnergySource EnergySource
        {
            get { return m_EnergySource; }
        }

        public Vehicle.eTypeOfVehicle TypeOfVehicle
        {
            get { return r_TypeOfVehicle; }
        }

        public int NumOfWheels
        {
            get { return m_NumOfWheels; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

         public static List<VehicleParameter> GetRequiredParameters()
          {
              List<VehicleParameter> parameters = new List<VehicleParameter>();
              parameters.Add(new VehicleParameter(typeof(string), "model"));
              parameters.Add(new VehicleParameter(typeof(string), "license number"));
              parameters.Add(new VehicleParameter(typeof(string), "wheels manufacturer"));

              return parameters;
          }

         public override string ToString()
         {
             string vehicleData = string.Format(
                                  "Model name: {1}{0}License number: {2}{0}Number of wheels: {3}{0}",
                                  Environment.NewLine,
                                  m_ModelName,
                                  m_LicenseNum, 
                                  m_NumOfWheels);

             return vehicleData + m_Wheels[0].ToString() + EnergySource.ToString();
         }
    }
}
