namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class CategoriaSaveCommand : IRequest<CategoriaResponse>
    {
        public CategoriaSaveCommand(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }

        public Categoria CommandToEntity(CategoriaSaveCommand categoriaSaveCommand)
        {
           return new Categoria(categoriaSaveCommand.Nome);
        }
    }
}
