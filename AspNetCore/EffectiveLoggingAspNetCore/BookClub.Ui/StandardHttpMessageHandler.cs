using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;

namespace BookClub.UI;

public class StandardHttpMessageHandler : DelegatingHandler
{
    private readonly HttpContext _httpContext;
    private readonly ILogger _logger;
    public StandardHttpMessageHandler(HttpContext httpContext, ILogger logger)
    {
        _httpContext = httpContext;
        _logger = logger;
        InnerHandler = new SocketsHttpHandler();
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        //var token = await _httpContext.GetTokenAsync("access_token");

        var token = "DEFAULT TOKEN";
        
        //request.Headers.Add("Authorization", $"Bearer {token}");
        var response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = "";
            var id = "";

            if (response.Content.Headers.ContentLength > 0)
            {
                var j = JObject.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
                error = (string)j["Title"]!;
                id = (string)j["Id"]!;
            }

            var ex = new Exception("API Failure");

            ex.Data.Add("API Route", $"GET {request.RequestUri}");
            ex.Data.Add("API Status", (int)response.StatusCode);
            if (!string.IsNullOrEmpty(error))
            {
                ex.Data.Add("API Error", error);
                ex.Data.Add("API ErrorId", id);
            }

            _logger.LogInformation("Api Error: {Exception}, Route :{Route}",
                ex, request.RequestUri);
            
            throw ex;
        }
        return response;
    }
}