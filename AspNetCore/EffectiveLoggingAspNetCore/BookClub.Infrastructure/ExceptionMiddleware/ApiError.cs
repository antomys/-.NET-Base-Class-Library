namespace BookClub.API.ExceptionMiddleware;

public struct ApiError
{
    public string Id { get; set; }
    
    public string Code { get; set; }
    
    public string Link { get; set; }
}