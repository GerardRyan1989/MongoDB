using Newtonsoft.Json;

namespace MongoDBCA
{
    public class Value
    {

        [JsonProperty("count")]
        public string TotalFighter { get; set; }

        [JsonProperty("averageHeight")]
        public string AverageHeight { get; set; }
    }
}