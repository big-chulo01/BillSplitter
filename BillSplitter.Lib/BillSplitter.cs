namespace BillSplitter.Lib;

public class BillSplitter
{
    public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
    {
        if (numberOfPeople <= 0)
            throw new ArgumentException("Number of people must be greater than zero.", nameof(numberOfPeople));
            
        return totalAmount / numberOfPeople;
    }

    public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        if (tipPercentage < 0)
            throw new ArgumentException("Tip percentage cannot be negative.", nameof(tipPercentage));
            
        var totalMealCost = mealCosts.Values.Sum();
        var tipAmount = totalMealCost * (decimal)(tipPercentage / 100);
        
        return mealCosts.ToDictionary(
            entry => entry.Key,
            entry => entry.Value / totalMealCost * tipAmount
        );
    }

    public decimal TipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
    {
        if (numberOfPatrons <= 0)
            throw new ArgumentException("Number of patrons must be greater than zero.", nameof(numberOfPatrons));
            
        if (tipPercentage < 0)
            throw new ArgumentException("Tip percentage cannot be negative.", nameof(tipPercentage));
            
        var totalTip = price * (decimal)(tipPercentage / 100);
        return totalTip / numberOfPatrons;
    }
}