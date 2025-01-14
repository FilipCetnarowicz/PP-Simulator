namespace Simulator.Maps;
public abstract class SmallMap : Map
{
    public Dictionary<Point, List<Creature>> Participants = new();
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            { throw new ArgumentOutOfRangeException("maximum size - 20x20"); }
    }

    public void Add(Creature creature, Point position)
    {
        if (!this.Exist(position)) 
            throw new ArgumentOutOfRangeException("Invalid point. Check map size");
        if (!Participants.ContainsKey(position))
            Participants[position] = new List<Creature>();
        Participants[position].Add(creature);
    }

    public void Remove(Creature creature, Point position)
    {
        if (!this.Exist(position))
            throw new ArgumentOutOfRangeException("Invalid point. Check map size");
        if (!Participants.ContainsKey(position) || !Participants[position].Contains(creature)) 
            throw new ArgumentException("Your creature is elsewhere.");
        Participants[position].Remove(creature);
        if (Participants[position].Count == 0)
            Participants.Remove(position);
    }

    public void Move(Creature creature, Point newPosition)
    {
        if (!this.Exist(newPosition))
            throw new ArgumentOutOfRangeException("Invalid point. Check map size");
        if (creature.CurrentPosition == null)
            throw new ArgumentException("This participant isn't on the map. Place him first.");
        var currentPosition = creature.CurrentPosition.Value;
        Participants[currentPosition].Remove(creature);
        if (Participants[currentPosition].Count==0)
            Participants.Remove(currentPosition);
        if (!Participants.ContainsKey(newPosition))
            Participants[newPosition] = new List<Creature>();
        Participants[newPosition].Add(creature);
    }

    public List<Creature> At(Point position)
    {
        if (!this.Exist(position)) 
            throw new ArgumentOutOfRangeException("Invalid point. Check map size.");
        if (!Participants.ContainsKey(position))
            throw new ArgumentException("There is no participant on this position.");
        return new List<Creature>(Participants[position]);
    }

    public List<Creature> At(int x, int y)
        { return At(new Point(x,y)); }

}