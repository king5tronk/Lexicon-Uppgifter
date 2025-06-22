using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private readonly T?[] vehicles;
        private int count = 0;

        public int Capacity { get; }

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[capacity];
        }

        public int Count => count;

        public bool ParkVehicle(T vehicle)
        {
            if (count >= Capacity)
                return false;

            // Kontrollera om regnumret redan finns
            foreach (var v in vehicles)
            {
                if (v != null && v.RegNr.Equals(vehicle.RegNr, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    count++;
                    return true;
                }
            }

            return false;
        }

        public bool RemoveVehicle(string regNr)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                var v = vehicles[i];
                if (v != null && v.RegNr.Equals(regNr, StringComparison.OrdinalIgnoreCase))
                {
                    vehicles[i] = null;
                    count--;
                    return true;
                }
            }
            return false;
        }


        public T? FindByRegNumber(string regNr)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null &&
                    vehicle.RegNr.Equals(regNr, StringComparison.OrdinalIgnoreCase))
                    return vehicle;
            }
            return null;
        }

        public IEnumerable<T> Search(Func<T, bool> predicate)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null && predicate(vehicle))
                    yield return vehicle;
            }
        }

        public IEnumerable<string> GetVehicleTypeSummary()
        {
            var typeCount = new Dictionary<string, int>();

            foreach (var vehicle in this)
            {
                string type = vehicle.GetType().Name;
                if (typeCount.ContainsKey(type))
                    typeCount[type]++;
                else
                    typeCount[type] = 1;
            }

            foreach (var kvp in typeCount)
            {
                yield return $"{kvp.Key}: {kvp.Value}";
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null)
                    yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

