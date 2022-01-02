using Microsoft.AspNetCore.Mvc;
using StockAnalyzer.Core;

namespace StockAnalyzer.Web.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        // Let's make sure that we can load the files when you start the project!
        var store = new DataCache();

        await store.LoadStocks();

        return View();
    }

    [Route("Stock/{ticker}")]
    public async Task<IActionResult> Stock(string ticker)
    {
        if (string.IsNullOrEmpty(ticker))
        {
            ticker = "MSFT";
        }
        
        ViewBag.Title = $"Stock Details for {ticker}";
        
        var store = new DataCache();

        var data = await store.LoadStocks();

        return View(data[ticker]);
    }
}