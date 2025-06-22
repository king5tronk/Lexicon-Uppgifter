using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }
        public Airplane(string regNr, string color, int wheels, int numberOfEngines) : base(regNr, color, wheels)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string Describe()
        {
            return $"Airplane | RegNr: {RegNr}, Color: {Color}, Wheels: {NumberOfWheels}, Engines: {NumberOfEngines}";
        }
    }
}
