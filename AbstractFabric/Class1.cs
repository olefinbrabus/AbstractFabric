namespace AbstractFabric;

using System;
public abstract class Car
{
    public abstract void Drive();
}

public abstract class Bicycle
{
    public abstract void Ride();
}
public class Sedan : Car
{
    public override void Drive()
    {
        Console.WriteLine("Sedan is driving.");
    }
}

public class MountainBike : Bicycle
{
    public override void Ride()
    {
        Console.WriteLine("Mountain bike is riding.");
    }
}
public abstract class TransportFactory
{
    public abstract Car CreateCar();
    public abstract Bicycle CreateBicycle();
}

public class CityTransportFactory : TransportFactory
{
    public override Car CreateCar()
    {
        return new Sedan();
    }

    public override Bicycle CreateBicycle()
    {
        return new UrbanBike();
    }
}

public class OffRoadTransportFactory : TransportFactory
{
    public override Car CreateCar()
    {
        return new Suv();
    }

    public override Bicycle CreateBicycle()
    {
        return new MountainBike();
    }
}

class Client
{
    public void CreateTransport(TransportFactory factory)
    {
        var car = factory.CreateCar();
        var bicycle = factory.CreateBicycle();

        car.Drive();
        bicycle.Ride();
    }
}

class Program
{
    static void Main()
    {
        var cityTransportFactory = new CityTransportFactory();
        var offRoadTransportFactory = new OffRoadTransportFactory();

        var client = new Client();

        Console.WriteLine("City Transport:");
        client.CreateTransport(cityTransportFactory);

        Console.WriteLine("\nOff-Road Transport:");
        client.CreateTransport(offRoadTransportFactory);
    }
}

public class Suv : Car
{
    public override void Drive()
    {
        Console.WriteLine("Suv is driving off-road.");
    }
}

public class UrbanBike : Bicycle
{
    public override void Ride()
    {
        Console.WriteLine("Urban bike is riding in the city.");
    }
}