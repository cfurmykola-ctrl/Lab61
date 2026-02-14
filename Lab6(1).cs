using System;
using System.Collections.Generic;
abstract class Vehicle
{
    public string Brand { get; set; }
    public int Speed { get; set; }

    public Vehicle(string brand, int speed)
    {
        Brand = brand;
        Speed = speed;
    }

    public abstract void Move();
}
interface IRefuelable
{
    void Refill();
}
class Car : Vehicle, IRefuelable
{
    public Car(string brand, int speed) : base(brand, speed) { }

    public override void Move()
    {
        Console.WriteLine($"Car {Brand} is driving on the road at {Speed} km/h.");
    }

    public void Refill()
    {
        Console.WriteLine($"Car {Brand} is refueling at the gas station.");
    }
}
class Bicycle : Vehicle
{
    public Bicycle(string brand, int speed) : base(brand, speed) { }

    public override void Move()
    {
        Console.WriteLine($"Bicycle {Brand} is moving by pedaling at {Speed} km/h.");
    }
}
class Airplane : Vehicle, IRefuelable
{
    public Airplane(string brand, int speed) : base(brand, speed) { }

    public override void Move()
    {
        Console.WriteLine($"Airplane {Brand} is flying at {Speed} km/h.");
    }

    public void Refill()
    {
        Console.WriteLine($"Airplane {Brand} is refueling before the flight.");
    }
}
class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("Toyota", 120),
            new Bicycle("Giant", 25),
            new Airplane("Boeing", 850)
        };

        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.Move();

            if (vehicle is IRefuelable refuelable)
            {
                refuelable.Refill();
            }

            Console.WriteLine();
        }
    }
}