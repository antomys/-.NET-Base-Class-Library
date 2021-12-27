// See https://aka.ms/new-console-template for more information


using WiredBrainCoffeeSurveys.Reports;

// Expression statements
var responseRate = Q1Results.NumberResponded / Q1Results.NumberSurveyed;
var unansweredCount = Q1Results.NumberSurveyed - Q1Results.NumberResponded;

// Expression statements
Console.WriteLine($"{responseRate};{unansweredCount}");
Console.WriteLine($"Is the coffee score higher that food? : {Q1Results.CoffeeScore > Q1Results.FoodScore}");
Console.WriteLine($"Would recommend? : {Q1Results.WouldRecommend >= 7}");
Console.WriteLine("Hate granola, love cappuccino : " +
                  $"{Q1Results.LeastFavoriteProduct is "Granola" && Q1Results.FavoriteProduct is "Cappuccino"}");
Console.WriteLine($"Overall score : {Q1Results.OverallRatings()}");