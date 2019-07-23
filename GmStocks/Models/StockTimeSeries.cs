using System;
using Newtonsoft.Json;

namespace GmStocks.Models
{
    public class TimeSeries
    {
        [JsonProperty("1. open")]
        public string The1Open { get; set; }

        [JsonProperty("2. high")]
        public string The2High { get; set; }

        [JsonProperty("3. low")]
        public string The3Low { get; set; }

        [JsonProperty("4. close")]
        public string The4Close { get; set; }

        [JsonProperty("5. volume")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long The5Volume { get; set; }
    }
}
