namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class LivroSaveCommand : IRequest<LivroResponse>
    {
        public LivroSaveCommand(string titulo, string resumo, string sumario, decimal preco, int numeroPaginas, string isbn, DateTime dataPublicacao, string categoria, string autor)
        {
            Titulo = titulo;
            Resumo = resumo;
            Sumario = sumario;
            Preco = preco;
            NumeroPaginas = numeroPaginas;
            Isbn = isbn;
            DataPublicacao = dataPublicacao;
            Categoria = categoria;
            Autor = autor;
        }

        public string Titulo { get; private set; }
        public string Resumo { get; private set; }
        public string Sumario { get; private set; }
        public decimal Preco { get; private set; }
        public int NumeroPaginas { get; private set; }
        public string Isbn { get; private set; }
        public DateTime DataPublicacao { get; private set; }
        public string Categoria { get; private set; }
        public string Autor { get; private set; }

        public Livro CommandToEntity(LivroSaveCommand livroSave)
        {
            return new Livro(new TituloLivro(livroSave.Titulo),
                              new ResumoLivro(livroSave.Resumo),
                              new SumarioLivro(livroSave.Sumario),
                              new PrecoLivro(livroSave.Preco),
                              new NumeroDePaginas(livroSave.NumeroPaginas),
                              new Isbn(livroSave.Isbn),
                              new DataPublicacao(livroSave.DataPublicacao),
                              new Categoria(livroSave.Categoria),
                              new AutorLivro(livroSave.Autor)
                              );
        }
    }
}