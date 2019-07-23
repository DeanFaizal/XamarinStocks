using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GmStocks.Models
{
    public class BaseStock
    {
        [JsonProperty("Meta Data")]
        public StockMetadata MetaData { get; set; }

        public virtual Dictionary<string, TimeSeries> TimeSeries { get; set; }
    }

    public class OneMinuteStock : BaseStock
    {
        [JsonProperty("Time Series (1min)")]
        public override Dictionary<string, TimeSeries> TimeSeries { get; set; }
    }

    public class FiveMinuteStock : BaseStock
    {
        [JsonProperty("Time Series (5min)")]
        public override Dictionary<string, TimeSeries> TimeSeries { get; set; }
    }

    public class FifteenMinuteStock : BaseStock
    {
        [JsonProperty("Time Series (15min)")]
        public override Dictionary<string, TimeSeries> TimeSeries { get; set; }
    }

    public class ThirtyMinuteStock : BaseStock
    {
        [JsonProperty("Time Series (30min)")]
        public override Dictionary<string, TimeSeries> TimeSeries { get; set; }
    }

    public class SixtyMinuteStock : BaseStock
    {
        [JsonProperty("Time Series (60min)")]
        public new Dictionary<string, TimeSeries> TimeSeries { get; set; }
    }
}
