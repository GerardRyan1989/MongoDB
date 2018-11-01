using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBCA
{
    public class MapReduceReturned
    {

        [JsonProperty("_id")]
        public string WeightClass { get; set; }

        public Value value { get; set; }

        
    }
}
