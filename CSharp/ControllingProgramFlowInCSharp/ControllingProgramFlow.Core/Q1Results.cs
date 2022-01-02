namespace ControllingProgramFlow.Core;

public class Q1Results
{
    // Aggregate ratings
    public double ServiceScore { get; set; } = 8.0;

    public double CoffeeScore { get; set; } = 8.5;

    public double PriceScore { get; set; } = 6.0;

    public double FoodScore { get; set; } = 7.5;
        
    public double OverallRatings() => (ServiceScore + CoffeeScore + PriceScore + FoodScore) / 4d;

    public double WouldRecommend { get; set; } = 6.5;

    public string FavoriteProduct { get; set; } = "Cappuccino";

    public string LeastFavoriteProduct { get; set; } = "Granola";

    // Aggregate counts
    public double NumberSurveyed { get; set; } = 500;

    public double NumberResponded { get; set; } = 325;

    public double NumberRewardsMembers { get; set; } = 130;

    public string Comment { get; set; } = string.Empty;
}
