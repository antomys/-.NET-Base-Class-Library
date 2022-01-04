using BookClub.Dal;
using Microsoft.EntityFrameworkCore;

namespace BookClub.API.Extensions;

public static class DatabaseExtension
{
    private const string DatabaseConnection = "BookClubDb";
    private const string MigrationAssemblyName = "BookClub.Dal";
    public static IServiceCollection AddDatabase(this IServiceCollection service, IConfiguration configuration)
    {
        return service.AddDbContext<BookClubDbContext>(
            builder => builder.UseSqlite
            (configuration.GetConnectionString(DatabaseConnection),
                x => x.MigrationsAssembly(MigrationAssemblyName)), 
            ServiceLifetime.Transient);
    }

    public static void SeedDatabase(BookClubDbContext? bookClubDbContext)
    {
        if (bookClubDbContext is null)
        {
            throw new ArgumentNullException(nameof(bookClubDbContext));
        }
        
        if (bookClubDbContext.Books.Any())
        {
            return;
        }
        
        bookClubDbContext.Books.AddRange(new Book
        {
            Title = "Carrion Comfort",
            Author = "Dan Simmons",
            Category = "Fiction",
            Genre = "Horror",
            Description = "Mind-vampires extend their control over others throughout the course of recent history"
        }, new Book
        {
            Title = "American Gods",
            Author = "Neil Gaiman",
            Category = "Fiction",
            Genre = "Sci-Fi/Fantasy",
            Description = "Crazy road trip across America involving a war between the old gods and new ones."
        });

        bookClubDbContext.SaveChanges();
    }
}