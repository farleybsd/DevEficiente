using Com.DevEficiente.CasaDoCodigo.Aplication.Result;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Queries
{
    public class AutorByIdQuery : IRequest<AutorByIdQueryResult>
    {
        public string Id { get; set; }
    }
}
