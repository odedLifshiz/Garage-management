// -----------------------------------------------------------------------
// <copyright file="VehicleNotFoundException.cs" company="Hewlett-Packard">
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
    public class VehicleNotFoundException : Exception
    {
        private readonly string r_licenseNum;

        public VehicleNotFoundException(string i_LicenseNum)
          : base()
        {
            r_licenseNum = i_LicenseNum;
        }

        public string LicenseNum
        {
            get { return r_licenseNum; }
        }
    }
}