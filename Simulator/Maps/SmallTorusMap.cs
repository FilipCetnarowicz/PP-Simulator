namespace Simulator.Maps;
public class SmallTorusMap : SmallMap
{
    // fields
    
    // constructors

    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    // methods

    public override Point Next(Point p, Direction d)
    {
        if (MapArea.Contains(p.Next(d))) return p.Next(d);
        int newX = (p.Next(d).X + SizeX) % SizeX;
        int newY = (p.Next(d).Y + SizeY) % SizeY;
        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (MapArea.Contains(p.NextDiagonal(d))) return p.NextDiagonal(d);
        int newX = (p.NextDiagonal(d).X + SizeX) % SizeX;
        int newY = (p.NextDiagonal(d).Y + SizeY) % SizeY;
        return new Point(newX, newY);
    }
}
