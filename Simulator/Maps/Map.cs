namespace Simulator.Maps;

public abstract class Map
{
    public int SizeX { get; init; }
    public int SizeY { get; init; }
    public Rectangle MapArea { get; init; }

    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY <5 )
            throw new ArgumentOutOfRangeException("minimum size - 5x5");
        SizeX = sizeX;
        SizeY = sizeY;
        MapArea = new Rectangle(0, 0, sizeX - 1, sizeY - 1);
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public bool Exist(Point p)
        { return MapArea.Contains(p); }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}