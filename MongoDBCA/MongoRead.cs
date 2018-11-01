using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDBCA
{
    public class MongoRead
    {

        public async Task<FighterProfile> getFighter(string firstname, string lastName)
        {

            FighterProfile result = null;
           

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Fighters");

            var collection = database.GetCollection<BsonDocument>("Fighters");

            
            if(firstname != "" && lastName != "")
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Name", firstname + " " + lastName);

                var returned = (await collection.Find(filter).ToListAsync()).FirstOrDefault();

                try
                {
                    result = BsonSerializer.Deserialize<FighterProfile>(returned);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Matching records in database!");
                }
                
            }
            else
            {
                MessageBox.Show("Please Enater a first and last name before searching!");
            }   
            return result;
        }
       
    }
}
