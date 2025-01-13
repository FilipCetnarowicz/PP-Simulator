using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;
using Simulator.Maps;

namespace TestSimulator;
public class ValidatorTests
{
    [Theory]
    [InlineData(0, 1, 10, 1)]
    [InlineData(1, 1, 10, 1)]
    [InlineData(2, 1, 10, 2)]
    [InlineData(9,1,10,9)]
    [InlineData(10,1,10,10)]
    [InlineData(11,1,10,10)]
    public void Limiter_ShouldReturnCorrectInt(int value, int min, int max, int expected)
    {
        // act
        var result = Validator.Limiter(value, min, max);
        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    // padding
    [InlineData("testtesttest   ",3,10,'#',"Testtestte")]
    [InlineData("   t   ",3,10,'#', "T##")]
    [InlineData("   test",3,10,'#', "Test")]
    public void Shoretener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        // act
        var result = Validator.Shortener(value, min, max, placeholder);
        // assert
        Assert.Equal(expected, result);
    }

}
