using VehicleManagementSystem.App;
using VehicleManagementSystem.Domain.Energy;
using VehicleManagementSystem.Domain.Vehicles;

Console.WriteLine("=== Vehicle Management Demo (Refactored) ===\n");

var car = new Car(
    make: "Honda",
    model: "Accord",
    year: 2023,
    price: 28000,
    initialFuelLevelPercent: Percentage.From(100m));

var motorcycle = new Motorcycle(
    make: "Harley-Davidson",
    model: "Street 750",
    year: 2022,
    price: 7500,
    initialFuelLevelPercent: Percentage.From(80m),
    hasSidecar: false);

var electricCar = new ElectricCar(
    make: "Tesla",
    model: "Model 3",
    year: 2023,
    price: 42000,
    initialBatteryLevelPercent: Percentage.From(100m));

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

