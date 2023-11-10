using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GestaoPessoa.Models
{
    public class Pessoa
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int Idade { get; set; }
        public string? Sexo { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? CEP { get; set; }
        public string? Estado { get; set; }
    }

}