namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class LivroByIdQueryHandler : IRequestHandler<LivroByIdQueryCommand, LivroByIdQueryResult>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroByIdQueryHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<LivroByIdQueryResult> Handle(LivroByIdQueryCommand request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetById(request.Id);

            if (livro == null)
                throw new LivroByIdQueryException();

            return new LivroByIdQueryResult()
            {
                Id = livro.Id,
                Nome = livro.Titulo.Titulo
            };
        }
    }
}