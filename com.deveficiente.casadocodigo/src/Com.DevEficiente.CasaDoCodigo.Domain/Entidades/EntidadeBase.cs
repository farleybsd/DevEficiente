namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class EntidadeBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}