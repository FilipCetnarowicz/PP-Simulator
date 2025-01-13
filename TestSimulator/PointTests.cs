using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;
using Simulator.Maps;

namespace TestSimulator;
public class PointTests
{
    [Theory]
    [InlineData(1,1,Direction.Up,1,2)]
    [InlineData(1,1,Direction.Right,2,1)]
    [InlineData(1,1,Direction.Down,1,0)]
    [InlineData(1,1,Direction.Left,0,1)]
    public void Next_ShouldReturnValidPoint(int startingX, int startingY, Direction direction, int expectedX, int expectedY)
    {
        // arrange
        var expected = new Point(expectedX, expectedY).ToString();
        var p1 = new Point(startingX, startingY);
        // act
        var result = p1.Next(direction).ToString();
        // assert
        Assert.Equal(expected, result);
    }

    
    [Theory]
    [InlineData(1, 1, Direction.Up, 2, 2)]
    [InlineData(1, 1, Direction.Right, 2, 0)]
    [InlineData(1, 1, Direction.Down, 0, 0)]
    [InlineData(1, 1, Direction.Left, 0, 2)]
    public void NextDiagonal_ShouldReturnValidPoint(int startingX, int startingY, Direction direction, int expectedX, int expectedY)
    {
        // arrange
        var expected = new Point(expectedX, expectedY);
        var p1 = new Point(startingX, startingY);
        // act
        var result = p1.NextDiagonal(direction);
        // assert
        Assert.Equal(expected, result);
    }
}
