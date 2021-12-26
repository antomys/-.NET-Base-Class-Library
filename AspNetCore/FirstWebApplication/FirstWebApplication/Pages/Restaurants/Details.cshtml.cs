using FirstWebApplication.Dal;
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstWebApplication.Pages.Restaurants;

public class Details : PageModel
{
    private readonly IRestaurantService _restaurantService;

    public Details(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService
            ?? throw new ArgumentNullException(nameof(restaurantService));
    }

    public Restaurant? Restaurant { get; private set; }
    
    public IActionResult OnGet(int restaurantId)
    {
        Restaurant = _restaurantService
            .GetRestaurant(x => x.Id == restaurantId)
            .FirstOrDefault();
        
        return Restaurant is null
        ? RedirectToPage("./NotFound")
        :Page();
    }
}