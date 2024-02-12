

using Com.DevEficiente.CasaDoCodigo.Domain.Entidades;
using Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio;

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
            var NomeCategoriaExiste = await _repository.BuscarCategoriaPorNome(request.Nome);

            if (NomeCategoriaExiste != null)
                throw new CategoriaSaveException();

            var categoriasave = request.CommandToEntity(request);
            await _repository.Add(categoriasave);
            return new CategoriaResponse()
            {
                Nome = request.Nome,
            };

        }
    }
}
