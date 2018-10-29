using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Windows.Forms;

namespace MongoDBCA
{
    public class MongoAdd
    {

        public async void AddFighter(FighterProfile fighter)
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Fighters");
            var collection = database.GetCollection<FighterProfile>("Fighters");


            fighter._id = ObjectId.GenerateNewId().ToString();

            try
            {
                await collection.InsertOneAsync(fighter);
                MessageBox.Show("Fighter Succesfully Added to Database");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please ensure a connection is active!");
            }

            
        }
    }
}
