using BookClub.Dal;
using BookClub.Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.Api.Controllers;

[TypeFilter(typeof(TrackPerformance))]
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookRepo;

    public BookController(IBookService bookRepo)
    {
        _bookRepo = bookRepo;
    }

    [HttpGet]
    public IEnumerable<Book> GetBooks()
    {
        //throw new InvalidDataException("Some exceptions for you");
        return _bookRepo.GetAllBooks();
        //return _bookRepo.GetAllBooksThrowError();
    }

    [HttpGet("{id:int}", Name = "Get")]
    public Book Get(int id)
    {
        return new Book();
    }

    // POST: api/Book
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Book/5
    [HttpPut("{id:int}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
    }
    
}
