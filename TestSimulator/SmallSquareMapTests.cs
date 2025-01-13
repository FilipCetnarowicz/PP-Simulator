using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;
using Simulator.Maps;

namespace TestSimulator;
public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ShouldThrowConstraints()
        { Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(21)); }

    [Theory]
    [InlineData(10,5,5,true)]
    [InlineData(10,15,15,false)]
    public void Exist_ShouldReturnValidLogic(int size, int pointX, int pointY, bool expected)
    {
        var p1 = new Point(pointX, pointY);
        var map1 = new SmallSquareMap(size);
        var result = map1.Exist(p1);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5,4,4,Direction.Up,4,4)]
    [InlineData(5,3,3,Direction.Up,3,4)]
    public void Next_ShouldReturnValidPoint(int size, int pointX, int pointY, Direction direction, int expectedPX, int expectedPY)
    {
        var map1 = new SmallSquareMap(size);
        var p1 = new Point(pointX,pointY);
        var result = map1.Next(p1,direction);
        var expected = new Point(expectedPX, expectedPY);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(5, 4, 4, Direction.Up, 4, 4)]
    [InlineData(5, 3, 3, Direction.Up, 4, 4)]
    public void NextDiagonal_ShouldReturnValidPoint(int size, int pointX, int pointY, Direction direction, int expectedPX, int expectedPY)
    {
        var map1 = new SmallSquareMap(size);
        var p1 = new Point(pointX, pointY);
        var result = map1.NextDiagonal(p1, direction);
        var expected = new Point(expectedPX, expectedPY);
        Assert.Equal(expected, result);
    }

    //public void NextDiagonal_ShouldReturnValidPoint()
    //{

    //}
}
