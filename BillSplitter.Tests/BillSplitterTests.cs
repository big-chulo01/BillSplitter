using BillSplitter.Lib;
using Xunit;

namespace BillSplitter.Tests;

public class BillSplitterTests
{
    private readonly Lib.BillSplitter _splitter;

    public BillSplitterTests()
    {
        _splitter = new Lib.BillSplitter();
    }

    [Theory]
    [InlineData(100, 5, 20)] // Even split
    [InlineData(100, 3, 33.33)] // Uneven split
    [InlineData(50, 2, 25)] // Simple split
    public void SplitAmount_ShouldReturnCorrectSplit(decimal totalAmount, int numberOfPeople, decimal expected)
    {
        var actual = _splitter.SplitAmount(totalAmount, numberOfPeople);
        Assert.Equal(expected, actual, 2); // Allowing 2 decimal places precision
    }

    [Fact]
    public void SplitAmount_ShouldThrowException_WhenPeopleZeroOrNegative()
    {
        Assert.Throws<ArgumentException>(() => _splitter.SplitAmount(100, 0));
        Assert.Throws<ArgumentException>(() => _splitter.SplitAmount(100, -1));
    }

    [Fact]
    public void CalculateTip_ShouldReturnCorrectWeightedTip()
    {
        var mealCosts = new Dictionary<string, decimal>
        {
            {"Alice", 20},
            {"Bob", 30},
            {"Charlie", 50}
        };
        float tipPercentage = 10f; // 10%
        
        var result = _splitter.CalculateTip(mealCosts, tipPercentage);
        
        Assert.Equal(2, result["Alice"]);
        Assert.Equal(3, result["Bob"]);
        Assert.Equal(5, result["Charlie"]);
    }

    [Fact]
    public void CalculateTip_ShouldReturnEmpty_WhenNoMealCosts()
    {
        var mealCosts = new Dictionary<string, decimal>();
        float tipPercentage = 15f;
        
        var result = _splitter.CalculateTip(mealCosts, tipPercentage);
        
        Assert.Empty(result);
    }

    [Fact]
    public void CalculateTip_ShouldThrowException_WhenNegativeTipPercentage()
    {
        var mealCosts = new Dictionary<string, decimal> { {"Alice", 20} };
        Assert.Throws<ArgumentException>(() => _splitter.CalculateTip(mealCosts, -5f));
    }

    [Theory]
    [InlineData(100, 4, 15, 3.75)] // 15% tip on 100 split 4 ways
    [InlineData(200, 5, 20, 8)] // 20% tip on 200 split 5 ways
    [InlineData(75, 3, 10, 2.5)] // 10% tip on 75 split 3 ways
    public void TipPerPerson_ShouldReturnCorrectAmount(decimal price, int numberOfPatrons, float tipPercentage, decimal expected)
    {
        var result = _splitter.TipPerPerson(price, numberOfPatrons, tipPercentage);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TipPerPerson_ShouldThrowException_WhenInvalidPatronsOrPercentage()
    {
        Assert.Throws<ArgumentException>(() => _splitter.TipPerPerson(100, 0, 15f));
        Assert.Throws<ArgumentException>(() => _splitter.TipPerPerson(100, -1, 15f));
        Assert.Throws<ArgumentException>(() => _splitter.TipPerPerson(100, 4, -5f));
    }
}