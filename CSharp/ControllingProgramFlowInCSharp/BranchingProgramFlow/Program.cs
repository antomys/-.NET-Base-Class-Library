using BranchingProgramFlow;
using ControllingProgramFlow.Core;

var tasks = new List<string>();
var result = new Q1Results();
// Expression statements
var responseRate = result.NumberResponded / result.NumberSurveyed * 100;
var _ = result.NumberSurveyed - result.NumberResponded;

if (result.CoffeeScore < result.FoodScore)
{
    tasks.Add("Investigate coffee recipes and ingredients.");
}

tasks.Add(result.OverallRatings() > 8f 
    ? "Work with leadership" 
    : "Work with employees");

switch (responseRate)
{
    case < 33d:
        tasks.Add("Improve response rate");
        break;
    case > 33d and < 66d:
        tasks.Add("Reward with coffee");
        break;
    default:
        tasks.Add("All cool! Discount coupon");
        break;
}

tasks.ForEach(Console.WriteLine);

var responses = new ForLoop();
responses.PrintResponseForLoop();
responses.PrintResponseForeach();
responses.PrintResponseLinq();