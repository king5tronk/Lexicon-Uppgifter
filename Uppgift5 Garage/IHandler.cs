namespace Uppgift5_Garage
    {
        public interface IHandler
        {
            bool AddVehicle(IVehicle vehicle);
            bool RemoveVehicle(string regNr);
            IVehicle? FindVehicle(string regNr);
            IEnumerable<IVehicle> ListAllVehicles();
            IEnumerable<string> GetVehicleTypeSummary();
            IEnumerable<IVehicle> SearchVehicles(string? regNr = null, string? color = null, int? wheels = null, string? type = null);
        void PopulateGarage();
            int VehicleCount { get; }
            int GarageCapacity { get; }
        }
    }
