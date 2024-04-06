namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class DetalhesDoLivroSiteQueryHandler : IRequestHandler<DetalhesDoLivroSiteCommand, DetalhesDoLivroSiteResponse>
    {
        private readonly ILivroRepository _livroRepository;

        public DetalhesDoLivroSiteQueryHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<DetalhesDoLivroSiteResponse> Handle(DetalhesDoLivroSiteCommand request, CancellationToken cancellationToken)
        {
            var autor = await _livroRepository.GetById(request.Id);

            return new DetalhesDoLivroSiteResponse()
            {
                Titulo = autor.Titulo.Titulo,
                Autor = new DetalhesAutorSiteResponse(autor.Autor.Nome),
                Isbn = autor.Isbn.isbn,
                NumeroPaginas = autor.NumeroDePaginas.NumeroPaginas,
                Preco = autor.PrecoLivro.Preco,
                Resumo = autor.Resumo.Resumo,
                DataPublicacao = autor.DataPublicacao.DataDePublicacao.ToString("dd/MM/yyyy")
            };
        }
    }
}