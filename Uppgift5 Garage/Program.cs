namespace Uppgift5_Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUI ui = new ConsoleUI();
            int capacity = ui.ReadInt("Ange garagekapacitet: ");
            IHandler handler = new GarageHandler(capacity);
            var controller = new GarageController(ui, handler);
            controller.Run();
        }
    }
}
