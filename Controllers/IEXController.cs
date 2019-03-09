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
        [HttpGet("OfficialOpenAndClose")]
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
        public async Task<List<IEXChart>> Chart(string symbol)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"https://api.iextrading.com/1.0/stock/{symbol}/chart");
                List<IEXChart> security = JsonConvert.DeserializeObject<List<IEXChart>>(json);
                return security;
            }
        }

        [HttpGet("ChartTest")]
        public async Task<IActionResult> ChartTest()
        {
            ViewBag.Chart = await Chart("msft");
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
    }
}
