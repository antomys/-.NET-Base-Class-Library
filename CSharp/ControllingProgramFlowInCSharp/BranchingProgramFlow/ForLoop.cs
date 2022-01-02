using Bogus;
using ControllingProgramFlow.Core;

namespace BranchingProgramFlow;

public class ForLoop
{
    private readonly List<Q1Results> _resultsList = new Faker<Q1Results>()
        .RuleFor(x => x.CoffeeScore, y => y.Random.Double(0d, 10d))
        .RuleFor(x => x.FavoriteProduct, y => y.Random.String2(10))
        .RuleFor(x => x.FoodScore, y => y.Random.Double(0d, 10d))
        .RuleFor(x => x.NumberResponded, y => y.Random.Double())
        .RuleFor(x => x.NumberSurveyed, y => y.Random.Double())
        .RuleFor(x => x.PriceScore, y => y.Random.Double(0d, 10d))
        .RuleFor(x => x.PriceScore, y => y.Random.Double(0d, 10d))
        .RuleFor(x => x.ServiceScore, y => y.Random.Double(0d, 10d))
        .RuleFor(x => x.WouldRecommend, y => y.Random.Double(5,10))
        .RuleFor(x => x.LeastFavoriteProduct, y => y.Random.String2(10))
        .RuleFor(x => x.NumberRewardsMembers, y => y.Random.Double())
        .RuleFor(x=>x.Comment, y=> y.Random.String2(0,20))
        .Generate(1000);

    public void PrintResponseForLoop()
    {
        for (var i = 0; i < _resultsList.Count; i++)
        {
            if (_resultsList[i].WouldRecommend < 7d)
            {
                Console.WriteLine($"{i}: {_resultsList[i].Comment}");
            }
        }
    }
    
    public void PrintResponseForeach()
    {
        foreach(var response in _resultsList)
        {
            if (response.WouldRecommend < 7d)
            {
                Console.WriteLine($"{response.Comment}");
            }
        }
    }
    
    public void PrintResponseLinq()
    {
        foreach (var response in _resultsList.Where(response => response.WouldRecommend < 7d))
        {
            Console.WriteLine($"{response.Comment}");
        }
    }
}