using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using StockAnalyzer.Core.Models;

namespace StockAnalyzer.Wpf.Services;

public class StockService
{        
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
        
    public static async Task<IEnumerable<StockPrice>?> GetStockPricesFor(string ticker)
    {
        using var client = new HttpClient();
        var result = await client.GetAsync($"http://localhost:7168/api/stocks/{ticker}");

        result.EnsureSuccessStatusCode();
        var content = await result.Content.ReadFromJsonAsync<IEnumerable<StockPrice>>(Options);

        return content;
    }
}