using BookClub.Dal;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookClub.UI.Pages
{
    public class BookListModel : PageModel
    {
        private readonly ILogger _logger;
        public List<Book> Books = default!;

        public BookListModel(ILogger<BookListModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            _logger.LogInformation("About to call API to get book list");
            using (var http = new HttpClient(new StandardHttpMessageHandler(HttpContext)))
            {
                Books = await http.GetFromJsonAsync<List<Book>>("http://localhost:5000/api/Book");
            }
        }
    }
}