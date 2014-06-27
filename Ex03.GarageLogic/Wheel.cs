// -----------------------------------------------------------------------
// <copyright file="Wheel.cs" company="Hewlett-Packard">
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
    public class Wheel
    {
        protected internal readonly float r_MaxAirPressure;
        protected internal string m_ManufacturerName;
        protected internal float m_CurrentAirPressure;

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            r_MaxAirPressure = i_MaxAirPressure;

            // New wheel starts with max air pressure
            m_CurrentAirPressure = i_MaxAirPressure;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public void InflateWheel(float i_HowMuchAirToFill)
        {
            // if the value is negative or it exceeds the max air pressure throw an excption
            if ((i_HowMuchAirToFill <= 0) || (i_HowMuchAirToFill + CurrentAirPressure > MaxAirPressure))
            {
                throw new ValueOutOfRangeException(MaxAirPressure - CurrentAirPressure, 0);
            }

            m_CurrentAirPressure += i_HowMuchAirToFill;
        }

        public void inflateWheelToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

        public void DeflateWheel(float i_HowMuchAirToDeflate)
        {
            // if the value is negative or it exceeds the max air pressure throw an excption
            if ((i_HowMuchAirToDeflate <= 0) || (CurrentAirPressure - i_HowMuchAirToDeflate < 0))
            {
                throw new ValueOutOfRangeException(MaxAirPressure - CurrentAirPressure, 0);
            }

            m_CurrentAirPressure -= i_HowMuchAirToDeflate;
        }

        public override string ToString()
        {
            string wheelData = string.Format(
                               "Manufacturer Name: {1}{0}Current Air Pressure: {2}{0}Max Air Pressure: {3}{0}", 
                               Environment.NewLine,
                               m_ManufacturerName, 
                               m_CurrentAirPressure, 
                               r_MaxAirPressure);
            return wheelData;
        }
    }
}
