using System.Globalization;
using StockAnalyzer.Core.Models;

namespace StockAnalyzer.Core;

public class DataCache
{
    private readonly Dictionary<string, Company> _companies = new();
    private static Dictionary<string, IEnumerable<StockPrice>> _stocks = new();
    private string BasePath { get; }

    public DataCache(string basePath = "")
    {
        BasePath = string.IsNullOrEmpty(basePath) ? Directory.GetCurrentDirectory() : basePath;
    }

    public async Task<Dictionary<string, IEnumerable<StockPrice>>> LoadStocks()
    {
        if (_stocks.Any())
        {
            return _stocks;
        }

        await LoadCompanies();

        var prices = await GetStockPrices();

        _stocks = prices
            .GroupBy(x => x.Ticker)
            .ToDictionary(x => x.Key ?? string.Empty, x => x.AsEnumerable());

        return _stocks;
    }

    private async Task LoadCompanies()
    {
        using var stream = new StreamReader(File.OpenRead(Path.Combine(BasePath, @"CompanyData.csv")));
        await stream.ReadLineAsync();

        string? line;
        while ((line = await stream.ReadLineAsync()) != null)
        {
            var segments = line.Split(',');

            for (var i = 0; i < segments.Length; i++) segments[i] = segments[i].Trim('\'', '"');

            var company = new Company
            {
                Symbol = segments[0],
                CompanyName = segments[1],
                Exchange = segments[2],
                Industry = segments[3],
                Website = segments[4],
                Description = segments[5],
                Ceo = segments[6],
                IssueType = segments[7],
                Sector = segments[8]
            };

            if (!_companies.ContainsKey(segments[0]))
            {
                _companies.Add(segments[0], company);
            }
        }
    }


    private async Task<IList<StockPrice>> GetStockPrices()
    {
        var prices = new List<StockPrice>();

        using var stream =
            new StreamReader(File.OpenRead(Path.Combine(BasePath, @"StockPrices_Small.csv")));
        await stream.ReadLineAsync(); // Skip headers

        string? line;
        while ((line = await stream.ReadLineAsync()) != null)
        {
            var segments = line.Split(',');

            for (var i = 0; i < segments.Length; i++) segments[i] = segments[i].Trim('\'', '"');
            var price = new StockPrice
            {
                Ticker = segments[0],
                TradeDate = DateTime.ParseExact(segments[1], "M/d/yyyy h:mm:ss tt",
                    CultureInfo.InvariantCulture),
                Volume = Convert.ToInt32(segments[6], CultureInfo.InvariantCulture),
                Change = Convert.ToDecimal(segments[7], CultureInfo.InvariantCulture),
                ChangePercent = Convert.ToDecimal(segments[8], CultureInfo.InvariantCulture),
            };
            prices.Add(price);
        }

        return prices;
    }
}