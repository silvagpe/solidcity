
// Bad: One class with many jobs
public class MultiTasker
{
    public void DoEverything()
    {
        Console.WriteLine("Guard gates!");
        Console.WriteLine("Fix lights!");
        Console.WriteLine("Feed bats!");
    }
}

// Good: One job per class
public class Gatekeeper
{
    public void Guard() { Console.WriteLine("Guard gates!"); }
}

public class Electrician
{
    public void Fix() { Console.WriteLine("Fix lights!"); }
}

public class Feeder
{
    public void Feed() { Console.WriteLine("Feed bats!"); }
}

public class SolidCitySRP
{
    public static void Main(string[] args)
    {
        // Usage
        var gatekeeper = new Gatekeeper();
        var electrician = new Electrician();
        var feeder = new Feeder();

        gatekeeper.Guard();
        electrician.Fix();
        feeder.Feed();
    }
}