using Com.DevEficiente.CasaDoCodigo.Aplication.Result;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class AutorByIdQueryCommand : IRequest<AutorByIdQueryResult>
    {
        public AutorByIdQueryCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
