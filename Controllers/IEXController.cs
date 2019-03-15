using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IEXStock.Models;
using IEXStock.Helpers;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IEXStock.Controllers
{
    [Route("IEX")]
    public class IEXController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        // Price
        [HttpGet("Price/{symbol}")]
        public async Task<string> Price(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/price");
            }
        }

        // Previous Day
        [HttpGet("PreviousDay/{symbol}")]
        public async Task<IEXPreviousDay> PreviousDay(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/previous");
                IEXPreviousDay security = JsonConvert.DeserializeObject<IEXPreviousDay>(json);
                return security;
            }
        }

        [HttpGet("PreviousDayTest")]
		public async Task<IActionResult> PreviousDayTest()
		{
            ViewBag.PreviousDay = await PreviousDay("msft");
			return View();
		}

        // Offical Open and Close 
        [HttpGet("OfficialOpenAndClose/{symbol}")]
        public async Task<IEXOfficalOpenAndClose> OfficalOpenAndClose(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/ohlc");
                IEXOfficalOpenAndClose security = JsonConvert.DeserializeObject<IEXOfficalOpenAndClose>(json);
                return security;
            }
        }

        [HttpGet("OfficalOpenAndCloseTest")]
        public async Task<IActionResult> OfficalOpenAndCloseTest()
        {
            ViewBag.OfficalOpenAndClose = await OfficalOpenAndClose("msft");
            return View();
        }

        // Stock Stats
        [HttpGet("StockStats/{symbol}")]
        public async Task<IEXStockStats> StockStats(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/stats");
                IEXStockStats security = JsonConvert.DeserializeObject<IEXStockStats>(json);
                return security;
            }
        }

        [HttpGet("StockStatsTest")]
        public async Task<IActionResult> StockStatsTest()
        {
            ViewBag.StockStats = await StockStats("msft");
            return View();
        }

        // Largest Trades Today
        [HttpGet("LargestTradesToday/{symbol}")]
        public async Task<List<IEXLargestTradesToday>> LargestTradesToday(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/largest-trades");
                List<IEXLargestTradesToday> security = JsonConvert.DeserializeObject<List<IEXLargestTradesToday>>(json);
                return security;
            }
        }

        [HttpGet("LargestTradesTodayTest")]
        public async Task<IActionResult> LargestTradesTodayTest()
        {
            ViewBag.LargestTradesToday = await LargestTradesToday("msft");
            return View();
        }

        // Logo
        [HttpGet("Logo/{symbol}")]
        public async Task<IEXLogo> Logo(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/logo");
                IEXLogo security = JsonConvert.DeserializeObject<IEXLogo>(json);
                return security;
            }
        }

        [HttpGet("LogoTest")]
        public async Task<IActionResult> LogoTest()
        {
            ViewBag.Logo = await Logo("msft");
            return View();
        }

        // Earning
        [HttpGet("Earning/{symbol}")]
        public async Task<IEXEarning> Earning(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/earnings");
                IEXEarning security = JsonConvert.DeserializeObject<IEXEarning>(json);
                return security;
            }
        }

        [HttpGet("EarningTest")]
        public async Task<IActionResult> EarningTest()
        {
            ViewBag.Earning = await Earning("msft");
            return View();
        }

        //https://api.iextrading.com/1.0/stock/aapl/chart
        // Chart
        [HttpGet("Chart/{symbol}")]
        public async Task<string> Chart(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/chart?format=csv");
            }
        }

        // MonthChart
        [HttpGet("MonthChart/{symbol}")]
        public async Task<string> MonthChart(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/chart/1m?format=csv");
            }
        }

        // OneYearChart
        [HttpGet("OneYearChart/{symbol}")]
        public async Task<string> OneYearChart(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/chart/1y?format=csv");
            }
        }

        // YearToDateChart
        [HttpGet("YearToDateChart/{symbol}")]
        public async Task<string> YearToDateChart(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/chart/ytd?format=csv");
            }
        }

        // DayChart
        [HttpGet("DayChart/{symbol}")]
        public async Task<(List<IEXDayChart>, string)> DayChart(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/chart/1d?format=csv");
                string json1 = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/chart/1d");
                List<IEXDayChart> stock = JsonConvert.DeserializeObject<List<IEXDayChart>>(json1);
                return (stock, json);
            }
        }

        [HttpGet("ChartTest")]
        public async Task<IActionResult> ChartTest()
        {
            var DayChartVar =  await DayChart("msft");
            ViewBag.DayChart = DayChartVar.Item2;
            ViewBag.DayChartText = DayChartVar.Item1;
            return View();
        }

        [HttpGet("ChartTest1")]
        public async Task<IActionResult> ChartTest1()
        {
            ViewBag.MonthChart = await MonthChart("msft");
            return View();
        }

        [HttpGet("ChartTest2")]
        public async Task<IActionResult> ChartTest2()
        {
            ViewBag.OneYearChart = await OneYearChart("msft");
            return View();
        }

        [HttpGet("ChartTest3")]
        public async Task<IActionResult> ChartTest3()
        {
            ViewBag.YearToDateChart = await YearToDateChart("msft");
            return View();
        }

        // https://api.iextrading.com/1.0/market
        // Markets
        [HttpGet("Markets")]
        public async Task<List<IEXMarkets>> Markets()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync("https://api.iextrading.com/1.0/market");
                List<IEXMarkets> markets = JsonConvert.DeserializeObject<List<IEXMarkets>>(json);
                return markets;
            }
        }

        [HttpGet("MarketsTest")]
        public async Task<IActionResult> MarketsTest()
        {
            ViewBag.Markets = await Markets();
            return View();
        }

        // https://api.iextrading.com/1.0/market
        // Markets
        [HttpGet("MarketChart")]
        public async Task<string> MarketChart()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync("https://api.iextrading.com/1.0/market");
            }
        }

        [HttpGet("MarketsTestPieChart")]
        public async Task<IActionResult> MarketsTestPieChart()
        {
            ViewBag.Markets = await MarketChart();
            return View();
        }

        // https://api.iextrading.com/1.0/tops?symbols=SNAP,fb,msft
        // TOPS
        [HttpGet("TOPS")]
        public async Task<List<IEXTOPS>> TOPS(string symbols)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/tops?symbols={symbols}");
                List<IEXTOPS> stocks = JsonConvert.DeserializeObject<List<IEXTOPS>>(json);
                return stocks;
            }
        }

        [HttpGet("TOPSJson")]
        public async Task<string> TOPSJson(string symbols)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/tops?symbols={symbols}");
            }
        }

        [HttpGet("TOPSTest")]
        public async Task<IActionResult> TOPSTest()
        {
            string stocks = "msft,aapl,sq,fb,amd,pypl,csco,intc";
            ViewBag.TOPS = await TOPS(stocks);
            //ViewBag.TOPSJson = await TOPSJson(stocks);
            return View();
        }
    }
}





// <div class="grid-container">
// @{
//     int counter = 0;
// }

// @foreach(var Stock in ViewBag.TOPS)
// {
//     <div class="grid-item">
//     <p>Symbol: @Stock.symbol</p>
//     @if(HttpContext.Session.GetInt32("@counter+BidPrice") == null)
//     {
//         HttpContext.Session.SetInt32("@counter+BidPrice", @Stock.bidPrice);
//     }
//     if(HttpContext.Session.GetInt32("@counter+BidPrice") > @Stock.bidPrice)
//     {
//         // RED
//         <p class="Red">Bid Price: @Stock.bidPrice</p>
        
//     }
//     else
//     {
//         // GREEN
//         <p class="Green">Bid Price: @Stock.bidPrice</p>
        
//     }
//     HttpContext.Session.SetInt32("@counter+BidPrice", @Stock.bidPrice;
    
    
    
//     <p class="AskPrice">Ask Price: @Stock.askPrice</p>
//     <p>Last Updated: @Time.FromUnixTime(Stock.lastUpdated)</p>
//     <p>Market Percent: @Stock.marketPercent</p>
//     </div>
//     counter++;
//     HttpContext.Session.SetInt32("@counter+BidPrice", @Stock.bidPrice);
// }

//
// [HttpGet]
// public string Get()
// {
//     HttpClient http = new HttpClient();
//     http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("APIKEY", header);
//     var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
//     return data;
// }