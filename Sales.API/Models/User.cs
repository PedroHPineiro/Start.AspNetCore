using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Sales.API.Models;

public class User
{
    [Required]
    [BsonId]
    // ObjectId é como o MongoDB lê o Id do Usuario que só pode ser uma String
    [BsonRepresentation(BsonType.ObjectId)]
    [StringLength(24, MinimumLength = 24 ,ErrorMessage="O Id precisa ter 24 digitos hex")]
    public string Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public int Telefone { get; set; }

    [StringLength(11 ,MinimumLength = 11, ErrorMessage = "O CPF precisa ter 11 digitos")]
    public string CPF { get; set; } = null!;
     
}