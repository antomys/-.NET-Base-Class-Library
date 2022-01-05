using BookClub.API.ExceptionMiddleware;
using BookClub.API.Extensions;
using BookClub.Dal;
using BookClub.Infrastructure.ExceptionMiddleware;
using BookClub.Infrastructure.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add(typeof(TrackActionPerformanceFilter));
    });

builder.Services
    .AddDatabase(builder.Configuration)
    .ConfigureServices()
    .ConfigureSwagger(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BookClubDbContext>();
    dbContext.Database.Migrate();
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

app.UseApiExceptionHandler(options =>
{
    options.AddResponseDetails = UpdateApiErrorResponse;
    options.DetermineLogLevel = DetermineLogLevel;
});
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();


void UpdateApiErrorResponse(HttpContext httpContext, Exception exception, ApiError apiError)
{
    if (exception.GetType().Name == nameof(Exception))
    {
        apiError.Link = "NO link, database shit";
    }
}

LogLevel DetermineLogLevel(Exception exception)
{
    return LogLevel.Critical;
}