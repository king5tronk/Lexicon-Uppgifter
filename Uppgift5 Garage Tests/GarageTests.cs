using Uppgift5_Garage.Vehicles;
using Uppgift5_Garage;

namespace Uppgift5_Garage_Tests
{
    public class GarageTests
    {
        [Fact]
        public void ParkVehicle_UniqueVehicle_ReturnsTrue()
        {
            // Arrange
            var garage = new Garage<Car>(2);
            var car = new Car("ABC123", "Röd", 4, "Ford", "Bensin");

            // Act
            var result = garage.ParkVehicle(car);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ParkVehicle_DuplicateRegNumber_ReturnsFalse()
        {
            // Arrange
            var garage = new Garage<Car>(2);
            var car1 = new Car("ABC123", "Röd", 4, "Ford", "Bensin");
            var car2 = new Car("ABC123", "Blå", 4, "Ford", "Diesel");

            // Act
            garage.ParkVehicle(car1);
            var result = garage.ParkVehicle(car2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveVehicle_ExistingVehicle_ReturnsTrue()
        {
            // Arrange
            var garage = new Garage<Car>(1);
            var car = new Car("XYZ789", "Svart", 4, "Ford", "Diesel");
            garage.ParkVehicle(car);

            // Act
            var result = garage.RemoveVehicle("XYZ789");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveVehicle_NonExistingVehicle_ReturnsFalse()
        {
            // Arrange
            var garage = new Garage<Car>(1);

            // Act
            var result = garage.RemoveVehicle("NOTFOUND");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void FindByRegNumber_ExistingVehicle_ReturnsVehicle()
        {
            // Arrange
            var garage = new Garage<Motorcycle>(1);
            var mc = new Motorcycle("BIKE1", "Gul", 2, 500);
            garage.ParkVehicle(mc);

            // Act
            var result = garage.FindByRegNumber("bike1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("BIKE1", result?.RegNr, ignoreCase: true);
        }

        [Fact]
        public void FindByRegNumber_NotFound_ReturnsNull()
        {
            // Arrange
            var garage = new Garage<Motorcycle>(1);

            // Act
            var result = garage.FindByRegNumber("MISSING");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ParkVehicle_WhenFull_ReturnsFalse()
        {
            // Arrange
            var garage = new Garage<Car>(1);
            garage.ParkVehicle(new Car("A1", "Röd", 4, "Ford", "Bensin"));

            // Act
            var result = garage.ParkVehicle(new Car("B2", "Blå", 4, "Ford", "Diesel"));

            // Assert
            Assert.False(result);
        }
    }
}
