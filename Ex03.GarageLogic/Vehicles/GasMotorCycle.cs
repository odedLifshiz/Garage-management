// -----------------------------------------------------------------------
// <copyright file="FuelMotorCycle.cs" company="Hewlett-Packard">
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
    public class GasMotorCycle : MotorCycle
    {
         public GasMotorCycle(GasMotorCycleData i_GasMotorCycleData)
             : base(i_GasMotorCycleData)
         {
             if (i_GasMotorCycleData == null)
             {
                 throw new IncompatibleVehicleDataException("gas motorcycle");
             }
         }
    }
}
