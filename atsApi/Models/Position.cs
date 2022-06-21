using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace atsApi.Models
{
    public class Position
    {
       [BsonId]
       [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        [MaxLength(300, ErrorMessage = "A descrição deve ter menos de 300 caracteres")]
        public string Description { get; set; }
    }
}
