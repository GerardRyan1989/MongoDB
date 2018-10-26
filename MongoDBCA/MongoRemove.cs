using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBCA
{
    public class MongoRemove
    {

        public async void Remove()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("cars");
            var collection = database.GetCollection<Object>("cars");

            collection.DeleteOne(a => a._id == "5bd24d0a6dcb7ddff588d3ad");

        }
    }
}
