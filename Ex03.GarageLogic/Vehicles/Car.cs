// -----------------------------------------------------------------------
// <copyright file="Car.cs" company="Hewlett-Packard">
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
    public abstract class Car : Vehicle
    {
        public Car(CarData i_CarData)
            : base(i_CarData)
        {
        }

        public enum eCarColor
        {
            Red = 1,
            Yellow = 2,
            Black = 3,
            Silver = 4,
        }

        public enum eNumOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }
    }
}
