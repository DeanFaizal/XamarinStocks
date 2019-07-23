using System;
using GmStocks.Models;

namespace GmStocks.Extensions
{
    public static class IntradayIntervalExtensions
    {
        public static string ToDescription(this IntradayIntervals intradayInterval)
        {
            switch (intradayInterval)
            {
                case IntradayIntervals.five:
                    return "5min";
                case IntradayIntervals.fifteen:
                    return "15min";
                case IntradayIntervals.thirty:
                    return "30min";
                case IntradayIntervals.sixty:
                    return "60min";
                case IntradayIntervals.one:
                default:
                    return "1min";
            }
        }
    }
}
