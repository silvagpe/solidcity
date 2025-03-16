# A different way of memorizing the SOLID principles

>First of all, I apologize for any mistakes in English, I'm not a native speaker, but I hope you'll be able to enjoy and have fun with this playful story. As naive as it may seem, the principles are true and follow good practice.

## A tale of Solid City. (1/5)

### Single Responsability Principal (SRP).

In the dark streets of SolidCity, a chaotic figure called Multi-Tasker wandered around, juggling several jobs at once: guarding the gates, fixing the lights and feeding the bats. The city suffered as he staggered around, burdened with too many responsibilities, whether it was queues at the gates, flickering light bulbs or hungry bats. Then a hero, the SRP Crusader, came along with a simple rule: “One job, one worker!” So the tasks of the Multi-Tasker were divided between, the Gatekeeper to guard the gates, the Electrician to fix the lights and the Feeder to feed the bats. Now, SolidCity thrives, each worker focused on a single task, proving that the Single Responsibility Principle keeps chaos under control.

```c#
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

// Usage
var gatekeeper = new Gatekeeper();
var electrician = new Electrician();
var feeder = new Feeder();

gatekeeper.Guard();
electrician.Fix();
feeder.Feed();
```


#### Explanation: Each class has one responsibility, making the code simple and easy to change, just like SolidCity’s workers!


## A tale of Solid City. (2/5)

### Open/closed principle (OCP).

In the foggy alleys of SolidCity, the old Gadget-Maker was hard at work, creating a single crime-fighting tool - a B-Blaster - that fired nets, smoke and flashbangs. Every time a new villain appeared, he dismantled the blaster to add features, leaving it broken and unreliable. Then one day the old Gadget-Maker heard a word of advice from his friend OCP Shadow. “Build it to grow, not to change!”. This advice never left his head, so he thought, I'll design a basic Blaster-Blueprint, open to new gadgets, like the Net-Launcher or the Smoke-Bomber, allowing new functions to be connected, without having to dismantle the original. Now, the heroes of SolidCity have easily expanded their arsenal while keeping the core safe and strong, thanks to the Open/Closed Principle.

```c#
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

public class BaseBlaster : IBlaster
{
    private blasters = new List<IBlaster>();
    public void Shoot() { 
        Console.WriteLine("Basic blast!"); 
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

// Usage
var blasters = new List<IBlaster> { new NetLauncher(), new SmokeBomber() };
foreach (var blaster in blasters)
{
    blaster.Shoot();
}
```

#### Explanation: The IBlaster interface lets you add new blaster types (like NetLauncher) without changing BaseBlaster. It’s open to grow with new features but closed to edits, keeping SolidCity’s gadgets reliable!

## A tale of Solid City. (3/5)

### Liskov's Substitution Principle

In the basement of the Kov mansion, Gear-Keeper built a reliable K-Vehicle - a sleek car that raced through the night to chase villains. He proudly handed it over to his apprentice, who built an A-Boat, claiming that it would fit the same function. However, when the A-Boat crashed on the streets instead of driving, it burst into flames and the car alarms went off, causing chaos in SolidCity. But luckily Dr. LSP was nearby and saw what happened, so he told the apprentice: “Every replacement must work like its father!” He showed them a K-Vehicle-Blueprint on which all K-Vehicles - cars or boats - could move reliably. Now, SolidCity's heroes were switching vehicles seamlessly, proving that Liskov's Substitution Principle keeps the mission on track.

```c#
// Bad: Substitution breaks behavior
public class KVehicle
{
    public virtual void Move() { Console.WriteLine("Drives on streets!"); }
}

public class ABoat : KVehicle
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
var vehicles = new List<IVehicle> { new BatCar(), new ABoat() };
foreach (var vehicle in vehicles)
{
    vehicle.Move(); // Works for both without breaking!
}
```

#### Explanation: The IVehicle interface ensures every vehicle (car or boat) can Move() in its own way, so substituting one for another doesn’t fail. This keeps SolidCity’s heroes rolling—or sailing—safely, following LSP!


## A tale of Solid City. (4/5)

### Interface Segregation Principle

In the cluttered workshops of SolidCity, the Blacksmith forged a huge B-Gadget - a heavy device packed with blades, lights and hooks for all the heroes. But when R1 picked it up, he felt the sheer weight of the B-Gadget, as he only needed the hook and R2 was fussing with blades, but really she just wanted the lights. Then Detective ISP said: “No hero should carry what they don't need!” Dividing the gadget into small tools. - Hook Tool, Light Tool, Blade Tool - each one light and perfect for its user. Now, SolidCity's heroes choose only what fits, proving that the Interface Segregation Principle keeps the fight lean and fast.

```C#
// Bad: One big interface forces unused methods
public interface IBGadget
{
    void Swing();
    void Shine();
    void Cut();
}

public class Robin : IBGadget
{
    public void Swing() { Console.WriteLine("Swings with hook!"); }
    public void Shine() { /* Doesn’t need this */ }
    public void Cut() { /* Doesn’t need this */ }
}

// Good: Small, specific interfaces
public interface IHookTool
{
    void Swing();
}

public interface ILightTool
{
    void Shine();
}

public interface IBladeTool
{
    void Cut();
}

public class R1 : IHookTool
{
    public void Swing() { Console.WriteLine("Swings with hook!"); }
}

public class R2 : IBladeTool
{
    public void Cut() { Console.WriteLine("Cuts with blade!"); }
}

// Usage
var r1 = new R1();
var r2 = new R2();
r1.Swing();
r2.Cut();
```

#### Explanation: Splitting the big IBGadget into smaller interfaces (IHookTool, ILightTool, IBladeTool) means R1 and R2 only use what they need. This keeps SolidCity’s code clean and lightweight, following ISP!

## A tale of Solid City. (5/5)

### Dependency Inversion Principle

In the busy streets of SolidCity, the B-Tower used a bell to warn people of danger. But when the bell broke, the tower couldn't switch to a new alert - it was stuck with the old system. A silent helper, the DIP, stepped in and said: “Don't attach the tower to a tool; instead, use a plan!” He created an Alert Plan so that the tower could work with bells, lights or anything else. Now, SolidCity's tower remained ready, easily changing alerts without any problems, thanks to the Dependency Inversion Principle that keeps it free of fixed tools.

```C#
// Bad: Tower depends on a specific bell
public class BTower
{
    private BellRinger _ringer = new BellRinger();
    public void Alert() { _ringer.Ring(); }
}

public class BellRinger
{
    public void Ring() { Console.WriteLine("Rings the bell!"); }
}

// Good: Tower uses an abstraction
public interface IAlarm
{
    void Sound();
}

public class BellRinger : IAlarm
{
    public void Sound() { Console.WriteLine("Rings the bell!"); }
}

public class LightFlasher : IAlarm
{
    public void Sound() { Console.WriteLine("Flashes the light!"); }
}

public class BTower
{
    private readonly IAlarm _alarm;
    public BTower(IAlarm alarm) { _alarm = alarm; }
    public void Alert() { _alarm.Sound(); }
}

// Usage
var towerWithBell = new BTower(new BellRinger());
var towerWithLight = new BTower(new LightFlasher());
towerWithBell.Alert();
towerWithLight.Alert();
```

#### Explanation: The BTower now uses the IAlarm plan, not just a BellRinger. This means it can switch to any alert (bell, light, etc.) without changing the tower’s code, following DIP to stay simple and flexible in SolidCity!



