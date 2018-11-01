using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBCA
{
    public class MongoMapReduce
    {
        public async Task<List<MapReduceReturned>> getMapReduce()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Fighters");
            var collection = database.GetCollection<BsonDocument>("Fighters");


            BsonJavaScript map = new BsonJavaScript(
                 "function(){" +
                 "   var fighter = this;" +
                 "   if (fighter.Age >= 30){" +
                 "       emit(fighter.WeightClass, {count: 1, Height: fighter.Height});" +
                 "   }" +
                 "};" 
                );

            BsonJavaScript reduce = new BsonJavaScript(
                "function(key, values) {" +
                "var result = {count: 0, totalHeight: 0.0};" +
                "" +
                "values.forEach(function(value){" +
                    "result.count += value.count;" +
                    "result.totalHeight += value.Height;" +
                      "" +
                "});" +
               
                "" +
                "return result;" +
                "};" 
            );

            BsonJavaScript finalize = new BsonJavaScript("" +
                " function(key, value) {" +
                "var result = {count : 0, averageHeight: 0};" +
                "   result.averageHeight = value.totalHeight / value.count;" +
                "   result.count = value.count;;" +
                "   return result;" +
                "};" );


            var options = new MapReduceOptions<BsonDocument, BsonDocument>();
            options.Finalize = finalize;
            options.OutputOptions = MapReduceOutputOptions.Inline;

            var results = collection.MapReduce<BsonDocument>(map, reduce, options).ToList();
            List<MapReduceReturned> resultList = new List<MapReduceReturned>();

            foreach (BsonDocument result in results)
            {

                var temp = result.ToJson();

                MapReduceReturned mapReturned = JsonConvert.DeserializeObject<MapReduceReturned>(temp);

                resultList.Add(mapReturned);

            }
           
            return resultList;
        }  
    }
}
