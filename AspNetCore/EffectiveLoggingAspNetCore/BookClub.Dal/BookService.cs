using Microsoft.EntityFrameworkCore;

namespace BookClub.Dal;

public class BookService : IBookService
{
    private readonly DbSet<Book> _books;

    public BookService(BookClubDbContext bookClubDbContext)
    {
        _books = bookClubDbContext.Books;
    }

    public List<Book> GetAllBooks()
    {
        return _books.ToList();
    }
}

public interface IBookService
{
    List<Book> GetAllBooks();
}