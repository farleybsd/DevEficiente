namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class AutorSaveCommand : IRequest<AutorResponse>
    {
        public AutorSaveCommand(string nome, string email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Descricao { get; private set; }

        public Autor CommandToEntity(AutorSaveCommand command)
        {
            return new Autor(command.Nome,new Email(command.Email),command.Descricao);
        }
    }
}
