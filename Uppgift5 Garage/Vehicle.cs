using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage
{
    public abstract class Vehicle : IVehicle
    {
        public string RegNr { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        protected Vehicle(string regNr, string color, int numberOfWheels)
        {
            RegNr = regNr;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        // Beskrivning som varje fordonstyp implementerar själv
        public abstract string Describe();
    }
}
