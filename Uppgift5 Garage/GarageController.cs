using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift5_Garage.Vehicles;

namespace Uppgift5_Garage
{
    public class GarageController
    {
        private readonly IUI ui;
        private readonly IHandler handler;

        public GarageController(IUI ui, IHandler handler)
        {
            this.ui = ui;
            this.handler = handler;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                string choice = ui.ShowMainMenu();

                switch (choice)
                {
                    case "1":
                        ListVehicles();
                        break;

                    case "2":
                        AddVehicle();
                        break;

                    case "3":
                        RemoveVehicle();
                        break;

                    case "4":
                        SearchVehicles();
                        break;

                    case "5":
                        ShowTypeSummary();
                        break;

                    case "6":
                        handler.PopulateGarage();
                        ui.ShowMessage("Garaget har fyllts med testdata.");
                        break;

                    case "0":
                        running = !ui.ReadYesNo("Är du säker på att du vill avsluta?");
                        break;

                    default:
                        ui.ShowMessage("Ogiltigt val. Försök igen.");
                        break;
                }

                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }

        private void ListVehicles()
        {
            var all = handler.ListAllVehicles();
            ui.ShowVehicles(all);
        }

        private void RemoveVehicle()
        {
            string regNr = ui.ReadString("Ange registreringsnummer att ta bort: ");
            if (handler.RemoveVehicle(regNr))
                ui.ShowMessage("Fordonet togs bort.");
            else
                ui.ShowMessage("Fordonet hittades inte.");
        }

        private void ShowTypeSummary()
        {
            var stats = handler.GetVehicleTypeSummary();
            ui.ShowList(stats);
        }

        private void SearchVehicles()
        {
            string regNr = ui.ReadString("Ange registreringsnummer (eller lämna tomt): ");
            string color = ui.ReadString("Ange färg (eller lämna tomt): ");

            int? wheels = null;
            if (ui.ReadYesNo("Vill du ange antal hjul?"))
                wheels = ui.ReadInt("Antal hjul: ");

            string type = ui.ReadString("Ange fordonstyp (eller lämna tomt): ");

            var results = handler.SearchVehicles(regNr, color, wheels, type);
            ui.ShowVehicles(results);
        }

        private void AddVehicle()
        {
            string type = "";
            IVehicle? vehicle = null;

            // Typval och validering först
            while (true)
            {
                type = ui.ReadString("Vilken typ av fordon vill du lägga till? (Car, Bus, Boat, Airplane, Motorcycle): ").ToLower();

                if (type is "car" or "bus" or "boat" or "airplane" or "motorcycle")
                    break;

                ui.ShowMessage("Ogiltig fordonstyp. Försök igen.");
            }

            // Samla in gemensam input
            string regNr = ui.ReadString("Ange registreringsnummer: ");
            string color = ui.ReadString("Ange färg: ");
            int wheels = ui.ReadInt("Ange antal hjul: ");

            // Skapa rätt typ av fordon
            vehicle = type switch
            {
                "car" => new Car(
                    regNr,
                    color,
                    wheels,
                    ui.ReadString("Ange modell: "),
                    ui.ReadString("Ange bränsletyp (t.ex. Bensin, Diesel, El): ")
                ),

                "bus" => new Bus(
                    regNr,
                    color,
                    wheels,
                    ui.ReadInt("Ange antal säten: ")
                ),

                "boat" => new Boat(
                    regNr,
                    color,
                    wheels,
                    ui.ReadInt("Ange längd (i meter): "),
                    type
                ),

                "airplane" => new Airplane(
                    regNr,
                    color,
                    wheels,
                    ui.ReadInt("Ange antal motorer: ")
                ),

                "motorcycle" => new Motorcycle(
                    regNr,
                    color,
                    wheels,
                    ui.ReadInt("Ange cylindervolym (cc): ")
                ),

                _ => null
            };

            if (handler.AddVehicle(vehicle))
                ui.ShowMessage("Fordonet lades till i garaget.");
            else
                ui.ShowMessage("Misslyckades. Registreringsnumret är kanske redan upptaget eller garaget är fullt.");
        }



    }
}
