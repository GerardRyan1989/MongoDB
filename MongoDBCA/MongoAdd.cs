﻿using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace MongoDBCA
{
    public class MongoAdd
    {

        public async void getDetails()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("cars");
            var collection = database.GetCollection<Object>("cars");


            var object1 = new Object {
                _id = ObjectId.GenerateNewId().ToString(), 
                Name = "Gerard Ryan",
                Age = "28"
            };

            await collection.InsertOneAsync(object1);

            var list = await collection.Find(x => x.Name == "Jack")
                .ToListAsync();

            foreach (var person in list)
            {
                Console.WriteLine(person.Name);
            }

            collection.DeleteOne(a => a._id == "5bd24d0a6dcb7ddff588d3ad");


            collection = database.GetCollection<Object>("cars");

            var list2 = await collection.Find(x => x.Name == "Jack")
                .ToListAsync();

            foreach (var person in list2)
            {
                Console.WriteLine(person.Name);
            }
        }



    }
}
