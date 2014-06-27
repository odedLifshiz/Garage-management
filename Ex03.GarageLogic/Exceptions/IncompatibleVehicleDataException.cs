// -----------------------------------------------------------------------
// <copyright file="IncompatibleVehicleDataException.cs" company="Hewlett-Packard">
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
    public class IncompatibleVehicleDataException : Exception
    {
        private string m_ExpectedVehicleData;

        public IncompatibleVehicleDataException(string i_ExpectedVehicleData)
        {
            m_ExpectedVehicleData = i_ExpectedVehicleData;
        }

        public string VehicleType
        {
            get { return m_ExpectedVehicleData; }
        }
    }
}
