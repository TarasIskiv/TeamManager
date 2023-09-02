using DataAnnotationsExtensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MinLength(3)]
        [BsonElement("n")]
        public string Name { get; set; } = string.Empty;
        [Min(18)]
        [Max(70)]
        [BsonElement("a")]
        public int Age { get; set; }
        [BsonElement("p")]
        public string Photo { get; set; } = string.Empty;
        [BsonElement("s")]
        [Required]
        [MinLength(3)]
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
        [Required]
        [MinLength(5)]
        public string Role { get; set; } = default!;
        [BsonElement("res")]
        public List<string> Responsibilities { get; set; } = new();
    }
}
