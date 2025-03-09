namespace SolidCityCLI.OCP;

// Bad: Modifying the class for every new feature
public class BBlaster
{
    public void Shoot(string type)
    {
        if (type == "Net") Console.WriteLine("Shoots net!");
        else if (type == "Smoke") Console.WriteLine("Shoots smoke!");
        else if (type == "Sparks") Console.WriteLine("Shoots sparks!");
    }
}

// Good: Open for extension, closed for modification
public interface IBlaster
{
    void Shoot();
}

public class Blaster : IBlaster
{
    private IList<IBlaster> Blasters = new List<IBlaster>();
    public void Shoot() { 
        foreach (var blaster in Blasters)
        {
            blaster.Shoot();
        }
    }

    public void Attach(IBlaster blaster)
    {
        Blasters.Add(blaster);
    }

    public void Detach(IBlaster blaster)
    {
        Blasters.Remove(blaster);
    }
    
}

public class NetLauncher : IBlaster
{
    public void Shoot() { Console.WriteLine("Shoots net!"); }
}

public class SmokeBomber : IBlaster
{
    public void Shoot() { Console.WriteLine("Shoots smoke!"); }
}


public class Program
{
    public static void Main(string[] args)
    {
        // Usage
        var blaster = new Blaster();
        blaster.Attach(new NetLauncher());
        blaster.Attach(new SmokeBomber());
        blaster.Shoot();
    }
}