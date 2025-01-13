using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simulator.Maps;
public class SmallTorusMap : Map
{
    // fields
    public int Size { get; init; }
    public Rectangle MapArea { get; init; }

    // constructors
    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException("size of Small Map must be between 5 and 20");
        Size = size;
        MapArea = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    // methods
    public override bool Exist(Point p)
        { return MapArea.Contains(p); }

    public override Point Next(Point p, Direction d)
    {
        if (MapArea.Contains(p.Next(d))) return p.Next(d);
        int newX = (p.Next(d).X + Size) % Size;
        int newY = (p.Next(d).Y + Size) % Size;
        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (MapArea.Contains(p.NextDiagonal(d))) return p.NextDiagonal(d);
        int newX = (p.NextDiagonal(d).X + Size) % Size;
        int newY = (p.NextDiagonal(d).Y + Size) % Size;
        return new Point(newX, newY);
    }


}
