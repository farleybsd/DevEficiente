using Com.DevEficiente.CasaDoCodigo.Aplication.Validadores;
using FluentValidation;

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
            var categoriasave = request.CommandToEntity(request);
            await _repository.Add(categoriasave);
            return new PaisResponse()
            {
                NomePais = request.NomePais,
            };
        }
    }
}