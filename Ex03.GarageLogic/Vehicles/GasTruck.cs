// -----------------------------------------------------------------------
// <copyright file="GasTruck.cs" company="Hewlett-Packard">
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
    public class GasTruck : CommercialVehicle
    {
        public GasTruck(GasTruckData i_GasTruckData)
            : base(i_GasTruckData)
        {
            if (i_GasTruckData == null)
            {
                throw new IncompatibleVehicleDataException("gas truck");
            }
        }
    }
}
