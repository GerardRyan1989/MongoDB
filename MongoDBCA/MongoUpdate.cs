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
        public async void updateFighter(FighterProfile fighter)
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Fighters");
            var collection = database.GetCollection<FighterProfile>("Fighters");

            var filter = Builders<FighterProfile>.Filter.Eq(s => s._id, fighter._id);
            var result = await collection.ReplaceOneAsync(filter, fighter);
        }
       
    }
}
