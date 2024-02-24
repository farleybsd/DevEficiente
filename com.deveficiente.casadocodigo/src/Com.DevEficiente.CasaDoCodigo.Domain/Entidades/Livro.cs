namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Livro
    {
        public Livro(TituloLivro titulo, ResumoLivro resumo, SumarioLivro sumario,
                     PrecoLivro precoLivro, NumeroDePaginas numeroDePaginas, Isbn isbn,
                     DataPublicacao dataPublicacao, Categoria categoria, AutorLivro autor)
        {
            Titulo = titulo;
            Resumo = resumo;
            Sumario = sumario;
            PrecoLivro = precoLivro;
            NumeroDePaginas = numeroDePaginas;
            Isbn = isbn;
            DataPublicacao = dataPublicacao;
            Categoria = categoria;
            Autor = autor;
        }

        public TituloLivro Titulo { get; private set; }
        public ResumoLivro Resumo { get; private set; }
        public SumarioLivro Sumario { get; private set; }
        public PrecoLivro PrecoLivro { get; private set; }
        public NumeroDePaginas NumeroDePaginas { get; private set; }
        public Isbn Isbn { get; private set; }
        public DataPublicacao DataPublicacao { get; private set; }
        public Categoria Categoria { get; private set; }
        public AutorLivro Autor { get; private set; }
    }
}
