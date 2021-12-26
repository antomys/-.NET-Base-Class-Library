using FirstWebApplication.Models;

namespace FirstWebApplication.Dal;

public interface IRestaurantService
{
    IEnumerable<Restaurant> GetRestaurants();
    IEnumerable<Restaurant> GetRestaurant(Func<Restaurant, bool> selector);
}