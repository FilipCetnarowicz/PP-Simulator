using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Rectangle
{
    // fields
    public int X1 { get; }
    public int Y1 { get; }
    public int X2 { get; }
    public int Y2 { get; }

    // constructors
    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 > x2) (x1, x2) = (x2, x1);
        if (y1 > y2) (y1, y2) = (y2, y1);

        if (y1 == y2 || x1 == x2) throw new ArgumentException("Nie chcemy \"chudych\" prostokatow");

        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }
    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }

    // methods
    public bool Contains(Point point)
    {
        if (point.X >= X1 && point.X <= X2 && point.Y >= Y1 && point.Y <= Y2) return true;
        else return false;
    }
    public override string ToString()
        { return $"({X1},{Y1}):({X2},{Y2})"; }
}
