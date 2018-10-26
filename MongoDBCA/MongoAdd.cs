using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace MongoDBCA
{
    public class MongoAdd
    {

        public async void Add()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("cars");
            var collection = database.GetCollection<Object>("cars");


            var object1 = new Object {
                _id = ObjectId.GenerateNewId().ToString(), 
                Name = "Stephen WONDERBOY Thompson",
                Age = "35"
            };

            await collection.InsertOneAsync(object1);
        }
    }
}
