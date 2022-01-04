using Microsoft.EntityFrameworkCore;

namespace BookClub.Dal;

public class BookClubDbContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;

    public BookClubDbContext(DbContextOptions<BookClubDbContext> contextOptions)
        :base(contextOptions) { }
}