using System.Security.Claims;
using BookClub.Infrastructure.Filters;
using NuGet.Packaging;

namespace BookClub.Ui.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureStuff(this IServiceCollection serviceCollection)
    {
        if (serviceCollection is null)
        {
            throw new ArgumentNullException(nameof(serviceCollection));
        }
        
        /*serviceCollection.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = _ => true;
            options.MinimumSameSitePolicy = SameSiteMode.Lax;
        });
        
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        serviceCollection.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = "https://demo.identityserver.io";

                options.ClientId = "interactive.confidential";
                options.ClientSecret = "secret";
                options.ResponseType = "code";
                options.Scope.Add("email");
                options.Scope.Add("api");
                options.Scope.Add("offline_access");

                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;
                options.ClaimActions.MapAllExcept("nbf", "exp", "aud", "nonce", "iat", "c_hash");
                options.Events.OnTicketReceived = e =>
                {
                    e.Principal = TransformClaims(e.Principal);
                    return Task.CompletedTask;
                };
            });*/

        serviceCollection.AddRazorPages();
        serviceCollection.AddControllers(config =>
        {
            config.Filters.Add(typeof(TrackPagePerformanceFilter));
            /*var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            config.Filters.Add(new AuthorizeFilter(policy));*/
        });

        return serviceCollection;
    }
    
    [Obsolete]
    private static ClaimsPrincipal TransformClaims(ClaimsPrincipal? principal)
    {
        var claims = new List<Claim>();
        claims.AddRange(principal?.Claims ?? throw new ArgumentNullException(nameof(principal)));  // retain any claims from originally authenticated user
            
        var newIdentity = new ClaimsIdentity(claims, principal.Identity?.AuthenticationType, "name", "role");
        return new ClaimsPrincipal(newIdentity);
    }
}