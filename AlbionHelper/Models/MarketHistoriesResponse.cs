using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlbionHelper.Models
{
    public class MarketHistoriesResponse
    {
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "item_id")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "quality")]
        public int Quality { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<MarketHistoryResponse> Data { get; set; }
    }
}
