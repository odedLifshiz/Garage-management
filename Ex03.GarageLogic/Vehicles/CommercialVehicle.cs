// -----------------------------------------------------------------------
// <copyright file="CommercialVehicle.cs" company="Hewlett-Packard">
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
    public abstract class CommercialVehicle : Vehicle
    {
        public CommercialVehicle(CommercialVehicleData i_CommercialVehicleData)
            : base(i_CommercialVehicleData)
        {
        }
    }
}