namespace Simulator.Maps;
public abstract class SmallMap : Map
{
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    { 
        if (sizeX > 20 || sizeY > 20)
            { throw new ArgumentOutOfRangeException("maximum size - 20x20"); }
    }
}
