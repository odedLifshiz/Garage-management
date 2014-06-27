// -----------------------------------------------------------------------
// <copyright file="ElectricMotorCycle.cs" company="Hewlett-Packard">
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
    public class ElectricMotorCycle : MotorCycle
    {
      public ElectricMotorCycle(ElectricMotorCycleData i_ElectricMotorCycleData)
          : base(i_ElectricMotorCycleData)
      {
          if (i_ElectricMotorCycleData == null)
          {
              throw new IncompatibleVehicleDataException("electric motorcycle");
          }
      }

      public void ChargeBattery(float i_HoursToAdd)
      {
          (VehicleData.EnergySource as ElectricBattery).ChargeBattery(i_HoursToAdd);
      }
    }
}
