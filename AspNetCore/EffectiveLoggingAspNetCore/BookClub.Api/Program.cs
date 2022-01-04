using BookClub.API.Extensions;
using BookClub.Dal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers();

builder.Services
    .AddDatabase(builder.Configuration)
    .ConfigureServices()
    .ConfigureSwagger(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BookClubDbContext>();
    dbContext?.Database?.Migrate();
    DatabaseExtension.SeedDatabase(dbContext);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Club API");
        /*options.OAuthClientId(app.Configuration.GetValue<string>("Security:ClientId"));
        options.OAuthClientSecret(app.Configuration.GetValue<string>("Security:ClientSecret"));
        options.OAuthAppName("Book Club API");
        options.OAuthUsePkce();*/
    });
}

app.UseHsts();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();