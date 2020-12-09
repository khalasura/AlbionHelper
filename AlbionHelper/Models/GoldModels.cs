using Newtonsoft.Json;
using System;

namespace AlbionHelper.Models
{
    public class GoldResponseModel
    {
        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
