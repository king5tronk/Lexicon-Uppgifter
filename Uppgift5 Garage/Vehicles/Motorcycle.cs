using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }
        public Motorcycle(string regNr, string color, int wheels, int cylinerVolume) : base(regNr, color, wheels)
        {
            CylinderVolume = cylinerVolume;
        }

        public override string Describe()
        {
            return $"Motorcycle | RegNr: {RegNr}, Color: {Color}, Wheels: {NumberOfWheels}, Cylinder: {CylinderVolume}cc";
        }
    }
}

