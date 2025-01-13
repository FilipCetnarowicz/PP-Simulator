using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public abstract class Creature
{
    // fields

    private string name = "Unknown";
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }
    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }
    
    public abstract int Power { get; }

    public abstract string Info { get; }

    // constructors
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }

    //methods
    public abstract string Greeting();

    public void Upgrade() =>
        level = level < 10 ? level + 1 : level;

    public string Go(Direction direction) =>
        $"{Name}[{Level}] goes {direction.ToString().ToLower()}.";
    public string[] Go(Direction[] directions) =>
        directions.Select(Go).ToArray();
    public string[] Go(string directionsToString) =>
        Go(DirectionParser.Parse(directionsToString));

    public override string ToString()
        { return $"{GetType().Name.ToUpper()}: {Info}"; }


}
