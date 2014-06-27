// -----------------------------------------------------------------------
// <copyright file="Vehicle.cs" company="Hewlett-Packard">
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
    public abstract class Vehicle
    {
        public enum eTypeOfVehicle
        {
            GasCar = 1,
            ElectricCar = 2,
            GasMotorcycle = 3,
            ElectricMotorcycle = 4,
            GasTruck = 5
        }

        private VehicleData m_VehicleData;

        public Vehicle(VehicleData i_VehicleData)
        {
            m_VehicleData = i_VehicleData;
        }

        public VehicleData VehicleData
        {
            get { return m_VehicleData; }
        }

          public override string ToString()
        {
            return this.m_VehicleData.ToString();
        }
    }
}
