namespace SolidCityCLI.LSP;

// Bad: Substitution fails
public class KVehicle
{
    public virtual void Move() { Console.WriteLine("Drives on streets!"); }
}

public class ABoatV1 : KVehicle
{
    public override void Move() { throw new Exception("Can’t drive, I’m a boat!"); }
}



// Good: Substitution works seamlessly
public interface IVehicle
{
    void Move();
}

public class BatCar : IVehicle
{
    public void Move() { Console.WriteLine("Drives on streets!"); }
}

public class ABoat : IVehicle
{
    public void Move() { Console.WriteLine("Sails on water!"); }
}

// Usage
public class Program
{
    public static void Main()
    {
        var vehicles = new List<IVehicle> { new BatCar(), new ABoat() };
        foreach (var vehicle in vehicles)
        {
            vehicle.Move(); // Works for both without breaking!
        }
    }
}