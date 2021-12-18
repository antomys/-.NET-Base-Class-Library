using FirstWebApplication.Models;

namespace FirstWebApplication.Dal;

public interface IRestaurantService
{
    IEnumerable<Restaurant> GetRestaurants();
    Restaurant? GetRestaurant(Func<Restaurant, bool> selector);
}