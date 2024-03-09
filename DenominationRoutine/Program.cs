
//Initialising
//Set Denominations
static List<int> GetDenonimations() { return new List<int> { 10, 50, 100 }; }
//Set Payouts
static List<int> GetPayouts() { return new List<int> { 30,50,60 ,80, 140, 230, 370, 610, 980 }; }

//Pass Values to Main
List<int> denominations = GetDenonimations();
List<int> payouts = GetPayouts();

//Handle any unforseen exceptions and print to screen
try
{
    //Loop through Payouts to get Combinations
    foreach (var amount in payouts)
    {
        var combinations = DetermineCombinations(amount, denominations);
        Console.WriteLine();
    }
}
catch (Exception ex)
{
    //Print Exceptions to Screen
    Console.WriteLine(ex.ToString());
}

#region Determine Combination of Denominations
/*Calculate Combination of Denominations
  Different scenarios:
  Handle for Empty and/or negative
*/
static List<List<int>> DetermineCombinations(int amount, List<int> denominations)
{   //Remember to handle when its -1
    //Zero Amount scenario
    if (amount == 0)
        return new List<List<int>> { new List<int>() };

    // Negative and 0 Denomination
    if (amount < 0 || denominations.Count == 0)
        return new List<List<int>>();

    // Determine combinations Case 1: without current denomination note
    var nonCurrent = DetermineCombinations(amount, denominations.Take(denominations.Count - 1).ToList());

    // Determine combinations Case 2: current denomination
    var withCurrent = new List<List<int>>();
    var remainingAmount = amount;
    var currentDenomination = denominations.Last();

    var result = remainingAmount / currentDenomination;

    //TODO: Handle for scenarios of remainders
    //Use Modulos to determine 
    if (remainingAmount % currentDenomination == 0)
    {
        Console.WriteLine($"Denomination Combinations for {amount} EUR:");
        Console.WriteLine($"{result} X {currentDenomination} EUR:");
        return nonCurrent;
    }
    
    if (remainingAmount % currentDenomination != 0)
    {
        var res = remainingAmount / currentDenomination;
        if (remainingAmount > currentDenomination)
        {
            Console.WriteLine($"{res} X {currentDenomination} EUR:");
            return nonCurrent;
        }
    
    }
    return withCurrent.Concat(nonCurrent).ToList();
}
#endregion

