using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDBCA
{
    public class MongoMapReduce
    {
        public async void getMapReduce()
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
                "   value.average = value.totalHeight / value.count;" +
                "   return value;" +
                "};" );


            var options = new MapReduceOptions<BsonDocument, BsonDocument>();
            options.Finalize = finalize;
            options.OutputOptions = MapReduceOutputOptions.Inline;







            var results = collection.MapReduce<BsonDocument>(map, reduce, options).ToList();

            foreach (var result in results)
            {
                Console.WriteLine(result.ToJson());
            }
        }  
    }
}
