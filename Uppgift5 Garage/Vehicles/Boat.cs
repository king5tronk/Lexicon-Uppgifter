using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage.Vehicles
{
    public class Boat : Vehicle
    {
        public int Length { get; set; }
        public string Type { get; set; }
        public Boat(string regNr, string color, int wheels, int length, string type) : base(regNr, color, wheels)
        {
            Length = length;
            Type = type;
        }
    }

}
