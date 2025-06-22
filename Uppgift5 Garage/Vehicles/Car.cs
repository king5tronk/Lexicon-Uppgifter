using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage.Vehicles
{
    public class Car : Vehicle
    {

        public string Model { get; set; }
        public string FuelType { get; set; }

        public Car(string regNr, string color, int wheels, string model, string fuelType) : base(regNr, color, wheels)
        {
            Model = model;
            FuelType = fuelType;
        }

        public override string Describe()
        {
            return $"Car | RegNr: {RegNr}, Color: {Color}, Wheels: {NumberOfWheels}, Fuel: {FuelType}";
        }
    }
}
