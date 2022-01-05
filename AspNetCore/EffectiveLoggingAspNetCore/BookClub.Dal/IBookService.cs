namespace BookClub.Dal;

public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
}