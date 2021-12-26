using FirstWebApplication.Models;

namespace FirstWebApplication.Dal;

public class InMemoryRestaurantService : IRestaurantService
{
    private readonly IList<Restaurant> _restaurants;
    public InMemoryRestaurantService()
    {
        _restaurants = new List<Restaurant>
        {
            new()
            {
                Id = 1,
                Name = "Test 1",
                Location = "TestLocation",
                Cuisine = Cuisine.German
            },
            new()
            {
                Id = 2,
                Name = "Test 2",
                Location = "TestLocation2",
                Cuisine = Cuisine.Italian
            }
        };
    }
    public IEnumerable<Restaurant> GetRestaurants()
    {
        return _restaurants.OrderBy(x=>x.Name);
    }

    public IEnumerable<Restaurant> GetRestaurant(Func<Restaurant, bool> selector)
    {
        return _restaurants.Where(selector);
    }
}