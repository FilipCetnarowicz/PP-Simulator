using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator.Maps;
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

    public SmallMap? CurrentMap { get; private set; }
    public Point? CurrentPosition { get; private set; }

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

    public void Go(Direction direction)
    {
        if (CurrentMap == null || CurrentPosition == null) 
            throw new InvalidOperationException("Creature isn't assigned yet. Use .AssignToMap()");
        var newPosition = CurrentPosition.Value.Next(direction);
        CurrentMap.Move(this, newPosition);
        CurrentPosition = newPosition;
    }

    public void AssignToMap(SmallTorusMap map, Point position)
    {
        if (CurrentMap != null) throw new InvalidOperationException("Creature is already assigned to map.");
        CurrentMap = map;
        CurrentPosition = position;
        map.Add(this, position);
    }

    public void AssignToMap(SmallTorusMap map, int x, int y)
        { AssignToMap(map, new Point(x, y)); }

    public override string ToString()
        { return $"{GetType().Name.ToUpper()}: {Info}"; }


}
