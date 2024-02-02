namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class AutorDeleteCommand : IRequest<string>
    {
        public AutorDeleteCommand(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}