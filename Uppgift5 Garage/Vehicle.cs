using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage
{
    public abstract class Vehicle
    {
        public string RegNr { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }

        public Vehicle(string regNr, string color, int wheels)
        {
            RegNr = regNr;
            Color = color;
            Wheels = wheels;
        }
    }
}
