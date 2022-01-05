using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookClub.Dal;

public class BookService : IBookService
{
    private readonly DbSet<Book> _books;
    private readonly ILogger<BookService> _logger;

    public BookService(BookClubDbContext bookClubDbContext, ILogger<BookService> logger)
    {
        _logger = logger;
        _books = bookClubDbContext.Books;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        using (_logger.BeginScope("Database shit"))
        {
            return _books.ToList();
        }
    }
}