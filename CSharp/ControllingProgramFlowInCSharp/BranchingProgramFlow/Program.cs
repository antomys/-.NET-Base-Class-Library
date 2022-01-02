using ControllingProgramFlow.Core;

var tasks = new List<string>();
// Expression statements
var responseRate = Q1Results.NumberResponded / Q1Results.NumberSurveyed * 100;
var unansweredCount = Q1Results.NumberSurveyed - Q1Results.NumberResponded;

if (Q1Results.CoffeeScore < Q1Results.FoodScore)
{
    tasks.Add("Investigate coffee recipes and ingredients.");
}

tasks.Add(Q1Results.OverallRatings() > 8f 
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