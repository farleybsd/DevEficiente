namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class AutorEditarCommand : IRequest<AutorResponse>
    {
        public AutorEditarCommand(string nome, string email, string descricao, string id)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;
            _id = id;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Descricao { get; private set; }

        public Autor CommandToEntity(AutorEditarCommand command)
        {
            var autor = new Autor(command.Nome, new Email(command.Email), command.Descricao);
            autor.Id = command._id;
            return autor;
        }
    }
}