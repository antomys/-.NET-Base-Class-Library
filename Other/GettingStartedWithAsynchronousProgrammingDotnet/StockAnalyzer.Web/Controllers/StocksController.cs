using Microsoft.AspNetCore.Mvc;
using StockAnalyzer.Core;

namespace StockAnalyzer.Web.Controllers;

public class StocksController : ControllerBase
{
    [Route("api/stocks/{ticker}")] 
    public async Task<IActionResult> Get(string ticker)
    {
        var store = new DataCache();

        var data = await store.LoadStocks();

        if (!data.ContainsKey(ticker)) return NotFound();

        return Ok(data[ticker]);
    }
}