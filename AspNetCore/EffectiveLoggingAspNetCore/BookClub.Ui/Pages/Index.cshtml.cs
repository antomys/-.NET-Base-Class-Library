using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookClub.UI.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }
        public void OnGet()
        {
            _logger.LogInformation("Hello from the Home Page!");
        }
    }
}
