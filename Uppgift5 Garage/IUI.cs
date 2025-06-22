using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift5_Garage
{
    public interface IUI
    {
        // Visar huvudmenyn och returnerar användarens val
        string ShowMainMenu();

        // Visar ett meddelande till användaren
        void ShowMessage(string message);

        // Läser en sträng från användaren (med prompt)
        string ReadString(string prompt);

        // Läser ett heltal från användaren (med validering)
        int ReadInt(string prompt);

        // Läser ett boolskt val (t.ex. ja/nej)
        bool ReadYesNo(string prompt);

        // Visar en lista med fordon eller texter
        void ShowList(IEnumerable<string> items);

        // Visar en lista med fordon (använder Describe())
        void ShowVehicles(IEnumerable<IVehicle> vehicles);
    }
}
