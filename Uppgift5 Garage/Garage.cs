using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage
{
    public class Garage<T> where T : Vehicle
    {
        private readonly T[] vehicles;
        private int count = 0;

        public int capacity { get; }

        public Garage(int capacity)
        {
            this.capacity = capacity;
            vehicles = new T[capacity];
        }

        public bool ParkVehicle(T vehicle)
        {
            if ( count >= capacity)
                return false;

            //kontroller om regNummer redan finns
            foreach (var v in vehicles)
            {
                if (v != null && v.RegNr.Equals(vehicle.RegNr, StringComparison.OrdinalIgnoreCase))
                    return false; // RegNr finns redan
            }
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    count++;
                    return true; // Parkering lyckades
                }
            }
            return false; // Garage är fullt


        }
        }
    }

