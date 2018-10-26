using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBCA
{
    public class FigtherProfile
    {
        [BsonRepresentation(BsonType.ObjectId)] 
        public string _id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public int Age { get; set; }

        public FightRecord WinLossRecord { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string WeightClass { get; set; }

        public FightStyle PrimaryFightStyle { get; set; }

        public List<FightStyle> AllFightStyle { get; set; }
    }
}
