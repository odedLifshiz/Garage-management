// -----------------------------------------------------------------------
// <copyright file="GasTank.cs" company="Hewlett-Packard">
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
    public class GasTank : EnergySource
    {
        private eGasType m_GasType;

        public GasTank(float i_GasTankCapacity, eGasType i_GasType)
            : base(i_GasTankCapacity)
        {
            m_GasType = i_GasType;
        }

        public eGasType GasType
        {
            get { return m_GasType; }
        }

        public enum eGasType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }
        
        public void AddFuel(float i_AddedFuelAmount, eGasType i_GasType)
        {
            if (m_GasType != i_GasType)
            {
                throw new ArgumentException();
            }

            AddEnergy(i_AddedFuelAmount);
        }

        public override string ToString()
        {
            string gasTankData = string.Format(
                                    "Energy type: Gas{0}" + 
                                    "Gas type: {1}",
                                    Environment.NewLine,
                                    m_GasType);
           
            return base.ToString() + gasTankData;
        }
    }
}
