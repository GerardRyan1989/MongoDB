using Newtonsoft.Json;

namespace MongoDBCA
{
    public class Value
    {

        [JsonProperty("count")]
        public string TotalFighter { get; set; }

        [JsonProperty("averageHeight")]
        public double AverageHeight { get; set; }
    }
}