using OOPSAssignment.VehicleManagementSystem.App;
using OOPSAssignment.VehicleManagementSystem.Domain.Energy;
using OOPSAssignment.VehicleManagementSystem.Domain.Entities;
using OOPSAssignment.VehicleManagementSystem.Domain.Vehicles;

Console.WriteLine("=== Vehicle Management Demo (Refactored) ===\n");

var car = new Car(new CarEntity(
    make: "Honda",
    model: "Accord",
    year: 2023,
    price: 28000,
    fuelLevelPercent: 100m));

var motorcycle = new Motorcycle(new MotorcycleEntity(
    make: "Harley-Davidson",
    model: "Street 750",
    year: 2022,
    price: 7500,
    fuelLevelPercent: 80m,
    hasSidecar: false));

var electricCar = new ElectricCar(new ElectricCarEntity(
    make: "Tesla",
    model: "Model 3",
    year: 2023,
    price: 42000,
    batteryLevelPercent: 100m));

Console.WriteLine("Testing Vehicles:");
car.Start();
Console.WriteLine(car.GetDisplayInfo());
car.Stop();

Console.WriteLine();
motorcycle.Start();
Console.WriteLine(motorcycle.GetDisplayInfo());

Console.WriteLine();
electricCar.Start();
Console.WriteLine(electricCar.GetDisplayInfo());

var manager = new VehicleManager();
manager.Add(car);
manager.Add(motorcycle);
manager.Add(electricCar);

manager.DisplayAll();
Console.WriteLine($"\nTotal Value: {manager.TotalValue()}");

Console.WriteLine("\nStarting all vehicles:");
manager.StartAll();

Console.WriteLine("\n=== Demo Complete ===");
