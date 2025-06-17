using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinerVolume { get; set; }
        public Motorcycle(string regNr, string color, int wheels, int cylinerVolume) : base(regNr, color, wheels)
        {
            CylinerVolume = cylinerVolume;
        }
    }
}

