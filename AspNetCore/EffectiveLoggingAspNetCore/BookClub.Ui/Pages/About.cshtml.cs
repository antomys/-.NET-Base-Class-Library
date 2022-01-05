using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookClub.UI.Pages
{
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
            throw new Exception("User should not see this");
        }
    }
}