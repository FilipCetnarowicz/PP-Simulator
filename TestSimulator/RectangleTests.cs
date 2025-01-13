using Simulator;
using Simulator.Maps;

namespace TestSimulator;
public class RectangleTests
{
    [Theory]
    [InlineData(1,1,3,3,5,5,false)]
    [InlineData(1,1,3,3,2,2,true)]
    [InlineData(1,1,3,3,3,3,true)]
    public void Contains_ShouldReturnValidLogic(int rectangleX1, int rectangleY1, int rectangleX2, int rectangleY2, int pointX1, int pointY1, bool expected)
    {
        // arrange
        var rectangleP1 = new Point(rectangleX1, rectangleY1);
        var rectangleP2 = new Point(rectangleX2, rectangleY2);
        var r1 = new Rectangle(rectangleP1,rectangleP2);
        var p1 = new Point(pointX1, pointY1);
        // act
        var result = r1.Contains(p1);
        // assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Constructor_ShouldThrowCollinear()
        { Assert.Throws<ArgumentException>(() => new Rectangle(1, 10, 1, 20)); }

    [Theory]
    [InlineData(5, 5, 1, 1, 1, 1, 5, 5)]
    [InlineData(1, 1, 5, 5, 1, 1, 5, 5)]
    public void Constructor_ValidSwapping(int inX1,int inY1, int inX2, int inY2, int outX1, int outY1, int outX2, int outY2)
    {
        // arrange
        var p1 = new Point(inX1, inY1);
        var p2 = new Point(inX2, inY2);
        var expected = new Rectangle(p1, p2).ToString();
        // act
        var result = new Rectangle(inX1, inY1, inX2, inY2).ToString();
        // assert
        Assert.Equal(expected, result);
    }
}
