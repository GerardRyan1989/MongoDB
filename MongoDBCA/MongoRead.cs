using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBCA
{
    public class MongoRead
    {

        public async Task<Object> get()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("cars");

            var collection = database.GetCollection<BsonDocument>("cars");


            var filter = Builders<BsonDocument>.Filter.Eq("Name", "GerardRyan");

            var returned = (await collection.Find(filter).ToListAsync()).FirstOrDefault();

            var result = BsonSerializer.Deserialize<Object>(returned);
          
            //initial commit

            return result;
        }
       
    }
}
