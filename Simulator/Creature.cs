using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Creature
{
    // fields
    public required string Name { get; init; }
    public int Level { get; set; }
    public string Info => $"{Name}, [{Level}]";

    // constructors
    public Creature (string name, int level = 1)
    {
        Name = name; 
        Level = level;
    }
    public Creature() { }

    //methods
    public void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.";

}
