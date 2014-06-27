// -----------------------------------------------------------------------
// <copyright file="GasCar.cs" company="Hewlett-Packard">
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
    public class GasCar : Car
    {
        public GasCar(GasCarData i_GasCarData)
            : base(i_GasCarData)
        {
            if (i_GasCarData == null)
            {
                throw new IncompatibleVehicleDataException("gas car");
            }
        }

        public void AddFuel(float i_FuelToAdd, GasTank.eGasType i_GasType)
        {
            (VehicleData.EnergySource as GasTank).AddFuel(i_FuelToAdd, i_GasType);
        }
    }
}
