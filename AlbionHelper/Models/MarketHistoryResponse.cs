using Newtonsoft.Json;
using System;

namespace AlbionHelper.Models
{
    public class MarketHistoryResponse
    {
        [JsonProperty(PropertyName = "item_count")]
        public int ItemCount { get; set; }

        [JsonProperty(PropertyName = "avg_price")]
        public int AveragePrice { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
