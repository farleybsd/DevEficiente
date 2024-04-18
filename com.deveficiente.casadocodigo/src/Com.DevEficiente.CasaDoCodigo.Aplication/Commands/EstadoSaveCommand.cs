namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class EstadoSaveCommand : IRequest<EstadoResponse>
    {
        public string _NomeEstado { get; private set; }
        public string _IdPais { get; private set; }

        public EstadoSaveCommand(string nomePais, string IdPais)
        {
            _NomeEstado = nomePais;
            _IdPais = IdPais;
        }

        public Estado CommandToEntity(EstadoSaveCommand paisSaveCommand)
        {
            return new Estado(paisSaveCommand._IdPais, paisSaveCommand._NomeEstado);
        }
    }
}