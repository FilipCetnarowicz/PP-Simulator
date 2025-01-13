namespace Simulator.Maps;
public class SmallSquareMap : SmallMap
{
    // fields
                
    // constructors

    public SmallSquareMap(int size) : base(size, size) { }

    // methods

    public override Point Next(Point p, Direction d)
    {
        if (MapArea.Contains(p.Next(d))) return p.Next(d);
        else return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (MapArea.Contains(p.NextDiagonal(d))) return p.NextDiagonal(d);
        else return p;
    }
}
