using Com.DevEficiente.CasaDoCodigo.Domain.NotificationObjects;
using Com.DevEficiente.CasaDoCodigo.Domain.ResultObjects;
using MongoDB.Driver;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class PaisSaveCommandHandler : IRequestHandler<PaisSaveCommand, Result<PaisResponse>>
    {
        private readonly IPaisRepository _repository;
        private readonly NotificationContext _notificationContext;

        public PaisSaveCommandHandler(IPaisRepository repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public async Task<Result<PaisResponse>> Handle(PaisSaveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pais = request.CommandToEntity(request);
                await _repository.Add(pais);
                return new Result<PaisResponse>()
                {
                    Succeeded = true,
                    Data = new PaisResponse()
                    {
                        NomePais = request.NomePais
                    }
                };
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                _notificationContext.AddNotification("MongoWriteException.ServerErrorCategory.DuplicateKey", "O país já existe.");
                return new Result<PaisResponse>()
                {
                    Succeeded = false,
                    Errors = new List<string>() { "O país já existe." }
                };
            }
        }
    }
}