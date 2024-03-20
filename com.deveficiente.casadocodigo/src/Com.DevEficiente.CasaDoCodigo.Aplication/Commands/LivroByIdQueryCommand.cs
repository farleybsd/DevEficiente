namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class LivroByIdQueryCommand : IRequest<LivroByIdQueryResult>
    {
        public LivroByIdQueryCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}