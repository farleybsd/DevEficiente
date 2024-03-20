using Com.DevEficiente.CasaDoCodigo.Aplication.Validadores;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class LivroSaveCommandHandler : IRequestHandler<LivroSaveCommand, LivroResponse>
    {
        private readonly ILivroRepository _repository;

        public LivroSaveCommandHandler(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<LivroResponse> Handle(LivroSaveCommand request, CancellationToken cancellationToken)
        {
            UniqueTite(request);
            var livro = request.CommandToEntity(request);
            await _repository.Add(livro);
            return new LivroResponse()
            {
                Titulo = request.Titulo,
                Sumario = request.Sumario,
                Preco = request.Preco,
                NumeroPaginas = request.NumeroPaginas,
                Isbn = request.Isbn,
                DataPublicacao = request.DataPublicacao,
                Categoria = request.Categoria,
                Autor = request.Autor
            };
        }

        private async void UniqueTite(LivroSaveCommand livroSaveCommand)
        {
            LivroSaveCommandValidation validator = new LivroSaveCommandValidation(_repository);

            var results = await validator.ValidateAsync(livroSaveCommand);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new LivroSaveException(failure.ErrorMessage);
                }
            }
        }
    }
}