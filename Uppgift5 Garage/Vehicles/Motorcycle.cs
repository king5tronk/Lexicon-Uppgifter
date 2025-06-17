using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public string Type { get; set; }


        public Motorcycle(string regNr, string color, int wheels, string type) : base(regNr, color, wheels)
        {
            Type = type;
        }


    }
}
