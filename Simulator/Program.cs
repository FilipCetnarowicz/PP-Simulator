using Simulator.Maps;
using System.Security.Cryptography;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5b();
    }

    static void Lab5b()
    {
        var SmallMapExample1 = new SmallSquareMap(5);
        var p1 = new Point(0, 0);
        var p2 = new Point(3, 3);
        var p3 = new Point(5, 5);
        
        p1 = SmallMapExample1.NextDiagonal(p1,Direction.Down);
        Console.WriteLine(p1);
        p2 = SmallMapExample1.Next(p2,Direction.Right);
        Console.WriteLine(p2);
        p3 = SmallMapExample1.Next(p3, Direction.Up);
        Console.WriteLine(p3);

        try { var SmallMapExample2 = new SmallSquareMap(4); }
        catch (ArgumentOutOfRangeException ex) 
            { Console.WriteLine($"Error in SmallMapExample2: {ex.Message}"); }

        try { var SmallMapExample3 = new SmallSquareMap(21); }
        catch (ArgumentOutOfRangeException ex)
            { Console.WriteLine($"Error in SmallMapExample3: {ex.Message}"); }
    }
    //static void Lab5a()
    //{
    //    Point p = new(10, 25);
    //    Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
    //    Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)

    //    Lab5a();

    //    //towrzenie z luznych wspolrzednych
    //    var r1 = new Rectangle(11, 1, 1, 11);
    //    Console.WriteLine($"r1: {r1}");
    //    Console.WriteLine(r1.Contains(new Point(5, 5)));

    //    //tworzenie z punktow
    //    var r2 = new Rectangle(new Point(1, 1), new Point(11, 11));
    //    Console.WriteLine($"r2: {r2}");
    //    Console.WriteLine(r2.Contains(new Point(5, 5)));

    //    //wyjatek
    //    try { var r3 = new Rectangle(1, 11, 1, 11); }
    //    catch (Exception ex) { Console.WriteLine($"exception: {ex.Message}"); }
    //}

    //static void Lab4b()
    //{
    //    object[] myObjects = {
    //    new Animals() { Description = "dogs"},
    //    new Birds { Description = "  eagles ", Size = 10 },
    //    new Elf("e", 15, -3),
    //    new Orc("morgash", 6, 4)
    //};
    //    Console.WriteLine("\nMy objects:");
    //    foreach (var o in myObjects) Console.WriteLine(o);
    //    /*
    //        My objects:
    //        ANIMALS: Dogs <3>
    //        BIRDS: Eagles (fly+) <10>
    //        ELF: E## [10][0]
    //        ORC: Morgash [6][4]
    //    */
    //}

    //static void Lab4a()
    //{
    //    Console.WriteLine("HUNT TEST\n");
    //    var o = new Orc() { Name = "Gorbag", Rage = 7 };
    //    o.SayHi();
    //    for (int i = 0; i < 10; i++)
    //    {
    //        o.Hunt();
    //        o.SayHi();
    //    }

    //    Console.WriteLine("\nSING TEST\n");
    //    var e = new Elf("Legolas", agility: 2);
    //    e.SayHi();
    //    for (int i = 0; i < 10; i++)
    //    {
    //        e.Sing();
    //        e.SayHi();
    //    }

    //    Console.WriteLine("\nPOWER TEST\n");
    //    Creature[] creatures = {
    //    o,
    //    e,
    //    new Orc("Morgash", 3, 8),
    //    new Elf("Elandor", 5, 3)
    //};
    //    foreach (Creature creature in creatures)
    //    {
    //        Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
    //    }
    //}

    //static void Lab3a()
    //{
    //    Creature c = new() { Name = "   Shrek    ", Level = 20 };
    //    c.SayHi();
    //    c.Upgrade();
    //    Console.WriteLine(c.Info);

    //    c = new("  ", -5);
    //    c.SayHi();
    //    c.Upgrade();
    //    Console.WriteLine(c.Info);

    //    c = new("  donkey ") { Level = 7 };
    //    c.SayHi();
    //    c.Upgrade();
    //    Console.WriteLine(c.Info);

    //    c = new("Puss in Boots – a clever and brave cat.");
    //    c.SayHi();
    //    c.Upgrade();
    //    Console.WriteLine(c.Info);

    //    c = new("a                            troll name", 5);
    //    c.SayHi();
    //    c.Upgrade();    
    //    Console.WriteLine(c.Info);

    //    var a = new Animals() { Description = "   Cats " };
    //    Console.WriteLine(a.Info);

    //    a = new() { Description = "Mice           are great", Size = 40 };
    //    Console.WriteLine(a.Info);
    //}

    //static void Lab3b()
    //{
    //    Creature c = new("Shrek", 7);
    //    c.SayHi();

    //    Console.WriteLine("\n* Up");
    //    c.Go(Direction.Up);

    //    Console.WriteLine("\n* Right, Left, Left, Down");
    //    Direction[] directions = {
    //    Direction.Right, Direction.Left, Direction.Left, Direction.Down
    //};
    //    c.Go(directions);

    //    Console.WriteLine("\n* LRL");
    //    c.Go("LRL");

    //    Console.WriteLine("\n* xxxdR lyyLTyu");
    //    c.Go("xxxdR lyyLTyu");
    //}
}

