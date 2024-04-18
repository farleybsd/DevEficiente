using MongoDB.Driver;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class EstadoSaveCommandHandler : IRequestHandler<EstadoSaveCommand, EstadoResponse>
    {
        private readonly IEstadoRepository _repository;

        public EstadoSaveCommandHandler(IEstadoRepository repository)
        {
            _repository = repository;
        }

        public async Task<EstadoResponse> Handle(EstadoSaveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var estado = request.CommandToEntity(request);
                await _repository.Add(estado);
                return new EstadoResponse()
                {
                    NomeEstado = request._NomeEstado,
                };
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                throw new ValidationException("O estado já existe.");
            }
        }
    }
}