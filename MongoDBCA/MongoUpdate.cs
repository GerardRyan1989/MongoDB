using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBCA
{
    public class MongoUpdate
    {
        public async void update()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("cars");
            var collection = database.GetCollection<Object>("cars");


            Object myObject = new Object
            {
                Name = "John Biones Jones",
                Age = "29"
            };

            

            var filter = Builders<Object>.Filter.Eq(s => s._id, "");
            var result = await collection.ReplaceOneAsync(filter, myObject);
        }
       
    }
}
