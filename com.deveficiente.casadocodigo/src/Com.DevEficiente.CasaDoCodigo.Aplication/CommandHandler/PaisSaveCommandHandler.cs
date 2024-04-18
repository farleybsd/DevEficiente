using MongoDB.Driver;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class PaisSaveCommandHandler : IRequestHandler<PaisSaveCommand, PaisResponse>
    {
        private readonly IPaisRepository _repository;

        public PaisSaveCommandHandler(IPaisRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaisResponse> Handle(PaisSaveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pais = request.CommandToEntity(request);
                await _repository.Add(pais);
                return new PaisResponse()
                {
                    NomePais = request.NomePais,
                };
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                throw new ValidationException("O país já existe.");
            }
        }
    }
}