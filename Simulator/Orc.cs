using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Orc : Creature
{
    // fields
    private int huntCounter;
    private int rage = 0;
    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }
    public override int Power
        { get { return 7 * Level + 3 * Rage; } }
    public override string Info
        { get { return $"{Name} [{Level}][{Rage}]"; } }

    // constructors
    public Orc() : base() { }
    public Orc(string name, int level = 1, int rage = 0) : base(name, level) 
        { Rage = rage; }

    // methods
    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        huntCounter++;
        if (huntCounter % 2 == 0)
        { 
            if  (rage < 10) rage++; 
            Console.WriteLine($"{Name}[{Level}] increased his rage to {rage} by hunting");
        }

    }
    public override void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}");
    
    
    
}
