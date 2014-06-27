// -----------------------------------------------------------------------
// <copyright file="ElectricCar.cs" company="Hewlett-Packard">
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
    public class ElectricCar : Car
    {
        public ElectricCar(ElectricCarData i_ElectricCarData)
            : base(i_ElectricCarData)
        {
            if (i_ElectricCarData == null)
            {
                throw new IncompatibleVehicleDataException("electric Car");
            }
        }

        public void ChargeBattery(float i_HoursToAdd)
        {
            (VehicleData.EnergySource as ElectricBattery).ChargeBattery(i_HoursToAdd);
        }
    }
}
