using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage
{
    public interface IVehicle
    {
        public string RegNr { get;  }
        public string Color { get; }
        public int NumberOfWheels { get; }
    }
}
