using Com.DevEficiente.CasaDoCodigo.Domain.DomainException;
using Com.DevEficiente.CasaDoCodigo.Domain.Validator;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Livro : EntidadeBase
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
            Valido();
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

        private void Valido()
        {
            LivroValidator validator = new LivroValidator();

            var results = validator.Validate(this);

            if (!results.IsValid)
            {
                throw new LivroDomainException((IEnumerable<FluentValidation.Results.ValidationFailure>)results.Errors);
            }
        }
    }
}