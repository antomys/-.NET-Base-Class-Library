using FirstWebApplication.Dal;
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstWebApplication.Pages.Restaurants;

public class List : PageModel
{
    private readonly IConfiguration _configuration;
    private readonly IRestaurantService _restaurantService;

    public List(IConfiguration configuration, IRestaurantService restaurantService, IEnumerable<Restaurant> restaurants)
    {
        _configuration = configuration
            ?? throw new ArgumentNullException(nameof(configuration));
        _restaurantService = restaurantService
                             ?? throw new ArgumentNullException(nameof(restaurantService));
    }

    public string Message { get; set; } = string.Empty;
    
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; } = default!;
    public IEnumerable<Restaurant> Restaurants { get; private set; } = default!;
    public void OnGet()
    {
        Message = _configuration[nameof(Message)];
        Restaurants = string.IsNullOrWhiteSpace(SearchTerm)
        ? _restaurantService.GetRestaurants()
        :_restaurantService.GetRestaurant(x=> x.Name.Contains(SearchTerm, StringComparison.InvariantCultureIgnoreCase));
    }
}