using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace MongoDBCA
{
    public class MongoAdd
    {

        public async void Add()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("cars");
            var collection = database.GetCollection<FigtherProfile>("cars");


            List<FightStyle> styles = new List<FightStyle>();

           
            styles.Add(new FightStyle { Style = "Karate" });
            styles.Add(new FightStyle { Style = "KickBoxinf" });
            styles.Add(new FightStyle { Style = "BJJ" });


            var object1 = new FigtherProfile {
                _id = ObjectId.GenerateNewId().ToString(),
                Name = "Stephen  Thompson",
                Nickname = "Wonderboy",
                Age = 35,
                WinLossRecord = new FightRecord()
                {
                    Wins = 18,
                    Draws = 2,
                    Losses = 2
                },
                Height = 6.0,
                Weight = 170,
                WeightClass = "WelterWeight",
                PrimaryFightStyle = new FightStyle()
                {
                    Style = "Karate"
                },
                AllFightStyle = styles
                
            };

            await collection.InsertOneAsync(object1);
        }
    }
}
