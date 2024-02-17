using Com.DevEficiente.CasaDoCodigo.Aplication.Validadores;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class CategoriaSaveCommandHandler : IRequestHandler<CategoriaSaveCommand, CategoriaResponse>
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaSaveCommandHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoriaResponse> Handle(CategoriaSaveCommand request, CancellationToken cancellationToken)
        {
            Valido(request);
            var categoriasave = request.CommandToEntity(request);
            await _repository.Add(categoriasave);
            return new CategoriaResponse()
            {
                Nome = request.Nome,
            };
        }

        private async void Valido(CategoriaSaveCommand categoriaSaveCommand)
        {
            CategoriaSaveCommandValidation validator = new CategoriaSaveCommandValidation(_repository);

            var results = await validator.ValidateAsync(categoriaSaveCommand);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new CategoriaSaveException(failure.ErrorMessage);
                }
            }
        }
    }
}