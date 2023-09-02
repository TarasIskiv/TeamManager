using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Core.Models
{
    public class EmployeeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = default!;
        [BsonElement("n")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("a")]
        public int Age { get; set; }
        [BsonElement("p")]
        public string Photo { get; set; } = string.Empty;
        [BsonElement("s")]
        public string Surname { get; set; } = string.Empty;
        [BsonElement("tid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Teamid { get; set; } = default!;
        [BsonElement("af")]
        public DateTime ActiveFrom { get; set; }
        [BsonElement("at")]
        public DateTime? ActiveTo { get; set; } = null;
        [BsonElement("kh")]
        public bool KeepHistory { get; set; } = true;
        [BsonElement("r")]
        public string Role { get; set; } = default!;
        [BsonElement("res")]
        public List<string> Responsibilities { get; set; } = new();
    }
}
