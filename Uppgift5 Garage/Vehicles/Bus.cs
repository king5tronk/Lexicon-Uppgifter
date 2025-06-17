using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage.Vehicles
{
    public class Bus : Vehicle
    {
        public int Seats { get; set; }
        public Bus(string regNr, string color, int wheels, int seats) : base(regNr, color, wheels)
        {
            Seats = seats;
        }
    }

}
