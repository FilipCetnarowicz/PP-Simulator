using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Creature
{
    // fields

    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            value = value.Trim();
            if (value.Length > 25)
            {
                value = value.Substring(0, 25);
                value = value.Trim();
            }
            if (value.Length < 3) value = value.PadRight(3, '#');
            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }
            name = value;
        }
    }
    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            level = value < 1 ? 1 : value;
            level = level > 10 ? 10 : level;
        }
    }
    public string Info => $"{Name}, [{Level}]";

    // constructors
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }

    //methods
    public void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

    public void Upgrade() =>
        level = level < 10 ? level + 1 : level;

    public void Go(Direction direction) =>
        Console.WriteLine($"{Name}[{Level}] goes {direction.ToString().ToLower()}.");

    public void Go(Direction[] directions)
        { foreach (var direction in directions) Go(direction); }

    public void Go(string directionsToString) =>
        Go(DirectionParser.Parse(directionsToString)); 

}
