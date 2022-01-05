using BookClub.Dal;
using BookClub.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookRepo;
    private readonly ILogger<BookController> _logger;
    private readonly IScoreInformation _information;

    public BookController(IBookService bookRepo, IScoreInformation information, ILogger<BookController> logger)
    {
        _bookRepo = bookRepo;
        _information = information;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Book> GetBooks()
    {
        //using (_logger.BeginScope(_information.HostScopeInfo))
        //{
        return _bookRepo.GetAllBooks();
        //}
        //throw new InvalidDataException("Some exceptions for you");
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
