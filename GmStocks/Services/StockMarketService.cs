using System;
using System.Net.Http;
using GmStocks.Models;
using GmStocks.Extensions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GmStocks.Services
{
    public class StockMarketService
    {
        private readonly HttpClient _client = new HttpClient();


        private string GenerateUrl(string symbol, IntradayIntervals intradayInterval)
        {
            var interval = intradayInterval.ToDescription();
            return $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval={interval}&apikey=YX612V0DYAM9M5B3";
        }

        public async Task<BaseStock> GetStockAsync(string symbol, IntradayIntervals intradayInterval)
        {
            try
            {
                var url = GenerateUrl(symbol, intradayInterval);
                var result = await _client.GetStringAsync(url).ConfigureAwait(false);


                switch (intradayInterval)
                {
                    case IntradayIntervals.one:
                        return JsonConvert.DeserializeObject<OneMinuteStock>(result);
                    case IntradayIntervals.five:
                        return JsonConvert.DeserializeObject<FiveMinuteStock>(result);
                    case IntradayIntervals.fifteen:
                        return JsonConvert.DeserializeObject<FifteenMinuteStock>(result);
                    case IntradayIntervals.thirty:
                        return JsonConvert.DeserializeObject<ThirtyMinuteStock>(result);
                    case IntradayIntervals.sixty:
                        return JsonConvert.DeserializeObject<SixtyMinuteStock>(result);
                    default:
                        return JsonConvert.DeserializeObject<BaseStock>(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
