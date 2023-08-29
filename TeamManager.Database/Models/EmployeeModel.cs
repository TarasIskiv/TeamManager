using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Database.Models
{
    public class EmployeeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        [BsonElement("n")]
        public string Name { get; set; }
        [BsonElement("s")]
        public string Surname { get; set; }
        [BsonElement("tid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Teamid { get; set; }
        [BsonElement("af")]
        public DateTime ActiveFrom { get; set; }
        [BsonElement("at")]
        public DateTime? ActiveTo { get; set; } = null;
        [BsonElement("kh")]
        public bool KeepHistory { get; set; } = true;
    }
}
