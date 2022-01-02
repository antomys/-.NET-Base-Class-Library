using ControllingProgramFlow.Core;

var results = new Q1Results();
// Expression statements
var responseRate = results.NumberResponded / results.NumberSurveyed;
var unansweredCount = results.NumberSurveyed - results.NumberResponded;

// Expression statements
Console.WriteLine($"{responseRate};{unansweredCount}");
Console.WriteLine($"Is the coffee score higher that food? : {results.CoffeeScore > results.FoodScore}");
Console.WriteLine($"Would recommend? : {results.WouldRecommend >= 7}");
Console.WriteLine("Hate granola, love cappuccino : " +
                  $"{results.LeastFavoriteProduct is "Granola" && results.FavoriteProduct is "Cappuccino"}");
Console.WriteLine($"Overall score : {results.OverallRatings()}");