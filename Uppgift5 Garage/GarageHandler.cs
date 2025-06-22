using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Uppgift5_Garage.Vehicles;

namespace Uppgift5_Garage
{
    public class GarageHandler : IHandler
    {
        private Garage<Vehicle> garage;

        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }

        public int VehicleCount => garage.Count;
        public int GarageCapacity => garage.Capacity;

        public bool AddVehicle(IVehicle v)
        {
            if (v is Vehicle vehicle)
            {
                return garage.ParkVehicle(vehicle);
            }
            return false;
        }

        public bool RemoveVehicle(string regNr)
        {
            return garage.RemoveVehicle(regNr);
        }

        public IVehicle? FindVehicle(string regNr)
        {
            return garage.FindByRegNumber(regNr);
        }

        public IEnumerable<IVehicle> ListAllVehicles()
        {
            return garage.Cast<IVehicle>();
        }

        public IEnumerable<string> GetVehicleTypeSummary()
        {
            return garage.GetVehicleTypeSummary();
        }

        public IEnumerable<IVehicle> SearchVehicles(string? regNr = null, string? color = null, int? wheels = null, string? type = null)
        {
            return garage.Search(v =>
                (string.IsNullOrWhiteSpace(regNr) || v.RegNr.Equals(regNr, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(color) || v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                (!wheels.HasValue || v.NumberOfWheels == wheels.Value) &&
                (string.IsNullOrWhiteSpace(type) || v.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase))
            ).Cast<IVehicle>();
        }


        public void PopulateGarage()
        {
            AddVehicle(new Car("ABC123", "Röd", 4,"Ford", "Bensin"));
            AddVehicle(new Motorcycle("BIKE1", "Svart", 2, 600));
            AddVehicle(new Bus("BUS99", "Blå", 6, 50));
            AddVehicle(new Boat("BOAT7", "Vit", 0, 12, "Porsche"));
            AddVehicle(new Airplane("JET42", "Silver", 3, 2));
        }
    }
}
