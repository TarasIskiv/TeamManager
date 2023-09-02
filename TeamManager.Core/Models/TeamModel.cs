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
    public class TeamModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        [BsonElement("n")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("d")]
        public string Description { get; set; } = string.Empty;
    }
}
