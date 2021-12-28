using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using StockAnalyzer.Core.Models;

namespace StockAnalyzer.Wpf.Services
{
    public class StockService
    {
        public static async Task<IEnumerable<StockPrice>?> GetStockPricesFor(string ticker)
        {
            using var client = new HttpClient();
            var result = await client.GetAsync($"http://localhost:61363/api/stocks/{ticker}");

            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<StockPrice>>(content);
        }
    }
}