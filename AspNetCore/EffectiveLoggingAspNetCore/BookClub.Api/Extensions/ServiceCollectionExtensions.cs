using BookClub.Dal;
using BookClub.Infrastructure;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BookClub.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(
        this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
        {
            throw new ArgumentNullException(nameof(serviceCollection));
        }

        serviceCollection.AddSingleton<IScoreInformation, ScopeInformation>();
        serviceCollection.AddTransient<IBookService, BookService>();

        serviceCollection.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfig>();

        return serviceCollection;
    }

    public static IServiceCollection ConfigureSwagger(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        if (serviceCollection is null)
        {
            throw new ArgumentNullException(nameof(serviceCollection));
        }
        
        /*serviceCollection.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.Authority = configuration.GetValue<string>("Security:Authority");
                options.Audience = configuration.GetValue<string>("Security:Audience");
            });

        serviceCollection.AddAuthorization();*/

        serviceCollection.AddSwaggerGen(); 
        // configured in SwaggerConfig by transient dependency above

        serviceCollection.AddMvc(options =>
        {
            /*var builder = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser();
            options.Filters.Add(new AuthorizeFilter(builder.Build()));*/
        });
        
        return serviceCollection;
    }
}