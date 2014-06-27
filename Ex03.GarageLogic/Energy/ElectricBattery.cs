// -----------------------------------------------------------------------
// <copyright file="ElectricBattery.cs" company="Hewlett-Packard">
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
    public class ElectricBattery : EnergySource
    {
        public ElectricBattery(float i_Capacity)
            : base(i_Capacity)
        { 
        }

        public void ChargeBattery(float i_Amount)
        {
            AddEnergy(i_Amount);
        }

        public override string ToString()
        {
            return "Energy type: Gas" + base.ToString();
        }
    }
}
