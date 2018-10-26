using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBCA
{
    public class Object
    {
        [BsonRepresentation(BsonType.ObjectId)] 
        public string _id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
