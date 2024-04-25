using Com.DevEficiente.CasaDoCodigo.Domain.ResultObjects;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class PaisSaveCommand : IRequest<Result<PaisResponse>>
    {
        public string NomePais { get; private set; }

        public PaisSaveCommand(string nomePais)
        {
            NomePais = nomePais;
        }

        public Pais CommandToEntity(PaisSaveCommand paisSaveCommand)
        {
            return new Pais(paisSaveCommand.NomePais);
        }
    }
}