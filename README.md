# BillSplitter

A .NET 8.0 utility library for splitting bills and calculating tips with weighted averages.

## Features

- Split total amount equally among people
- Calculate tips based on weighted meal costs
- Determine equal tip amounts per person
- Comprehensive error handling

## Requirements Met

✅ **Project Structure**
- .NET 8.0 solution
- Class library project (`BillSplitter.Lib`)
- xUnit test project (`BillSplitter.Tests`)

✅ **Core Functionality**
1. `SplitAmount(decimal totalAmount, int numberOfPeople)`
   - Splits bill equally
   - Throws exception for zero/negative people

2. `CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)`
   - Weighted tip calculation
   - Handles empty dictionaries
   - Validates tip percentage

3. `TipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)`
   - Equal tip distribution
   - Validates patron count and tip percentage

✅ **Testing**
- 11 total tests (3+ for each method)
- Descriptive test names (Method_Scenario_ExpectedBehavior)
- 100% pass rate verified

## Installation

1. Ensure [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) is installed
2. Clone this repository
   ```bash
   git clone https://github.com/yourusername/BillSplitter.git
   cd BillSplitter
