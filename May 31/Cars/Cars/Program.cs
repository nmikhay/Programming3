using System;
using System.Collections.Generic;

class Vehicle
{
    public string Color { get; set; }
    public string Manufacturer { get; set; }
    public double Speed { get; set; }

    public Vehicle(string color, string manufacturer, double speed)
    {
        Color = color;
        Manufacturer = manufacturer;
        Speed = speed;
    }

    public virtual string Move()
    {
        return "The vehicle is moving.";
    }
}

class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    public Car(string color, string manufacturer, double speed, int numberOfDoors)
        : base(color, manufacturer, speed)
    {
        NumberOfDoors = numberOfDoors;
    }

    public override string Move()
    {
        return "The car is driving on the highway.";
    }
}

class Truck : Vehicle
{
    public double LoadCapacity { get; set; }

    public Truck(string color, string manufacturer, double speed, double loadCapacity)
        : base(color, manufacturer, speed)
    {
        LoadCapacity = loadCapacity;
    }

    public override string Move()
    {
        return "The truck is carrying a heavy load.";
    }
}

class Bike : Vehicle
{
    public bool HasBell { get; set; }

    public Bike(string color, string manufacturer, double speed, bool hasBell)
        : base(color, manufacturer, speed)
    {
        HasBell = hasBell;
    }

    public override string Move()
    {
        return "The bike is on a bike path.";
    }
}

class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        Car car = new Car("White", "Suzuki", 100.0, 4);
        vehicles.Add(car);

        Truck truck = new Truck("Blue", "TruckBrand", 80.0, 5000.0);
        vehicles.Add(truck);

        Bike bike = new Bike("Green", "BikeBrand", 20.0, true);
        vehicles.Add(bike);

        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine($"Color: {vehicle.Color}");
            Console.WriteLine($"Manufacturer: {vehicle.Manufacturer}");
            Console.WriteLine($"Speed: {vehicle.Speed}");
            Console.WriteLine(vehicle.Move());
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}

