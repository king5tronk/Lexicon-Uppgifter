using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage
{
    public abstract class Vehicle : IVehicle
    {
        public  string RegNr { get; set; }
        public  string Color { get; set; }
        public  int NumberOfWheels { get; set; }

        protected Vehicle(string regNr, string color, int wheels)
        {
            RegNr = regNr;
            Color = color;
            NumberOfWheels = wheels;
        }

    }
}
