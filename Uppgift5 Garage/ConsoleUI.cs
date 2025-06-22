using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage
{
    public class ConsoleUI : IUI
    {
        public string ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("=== GARAGE 1.0 ===");
            Console.WriteLine("1. Lista alla fordon");
            Console.WriteLine("2. Lägg till fordon");
            Console.WriteLine("3. Ta bort fordon");
            Console.WriteLine("4. Sök fordon");
            Console.WriteLine("5. Visa fordonsstatistik");
            Console.WriteLine("6. Populera garaget (testdata)");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj ett alternativ: ");

            return Console.ReadLine() ?? "";
        }


        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }


        public int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("Ingen inmatning. Försök igen.");
                    continue;
                }

                if (int.TryParse(input, out result))
                    return result;

                Console.WriteLine("Felaktig inmatning. Ange ett heltal.");
            }
        }


        public bool ReadYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (j/n): ");
                string? input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("Ingen inmatning – försök igen.");
                    continue;
                }

                input = input.ToLower();

                if (input == "j" || input == "ja")
                    return true;
                if (input == "n" || input == "nej")
                    return false;

                Console.WriteLine("Skriv 'j' för ja eller 'n' för nej.");
            }
        }


        public void ShowList(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowVehicles(IEnumerable<IVehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Describe());
            }
        }
    }
}
