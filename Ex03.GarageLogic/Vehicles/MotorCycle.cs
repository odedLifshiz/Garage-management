// -----------------------------------------------------------------------
// <copyright file="MotorCycle.cs" company="Hewlett-Packard">
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
    public abstract class MotorCycle : Vehicle
    {
        public MotorCycle(MotorCycleData i_MotorCycleData)
            : base(i_MotorCycleData)
        { 
        }

        public enum eMotorCycleLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B1 = 4
        }
    }
}
