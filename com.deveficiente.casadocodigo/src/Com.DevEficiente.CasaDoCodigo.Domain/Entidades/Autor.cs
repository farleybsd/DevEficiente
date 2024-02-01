using Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Autor
    {
        public Autor(string nome, Email email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;
            Instante = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public DateTime Instante { get; private set; }
        public string Descricao  { get; private set; }
    }
}
