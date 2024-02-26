using Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Validator
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        private readonly IRepository<Livro> LivroCollection;
        public LivroValidator()
        {
            TituloObrigatorio();
            ResumoObrigatorio();
            SumarioObrigatorio();
            PrecoNaoPodeSerZerado();
            NumeroDePaginasNaoPodeSerZerado();
            ResumoNaoPodeTerMaisDe500Caracteres();
            DataPublicacaoPrecisaSerNoFuturo();
            CategoriaObrigatoria();
            AutorLivroObrigatoria();
        }

        private void TituloObrigatorio()
        {
            RuleFor(x => x.Titulo.Titulo)
            .NotNull()
            .WithMessage("O Título é obrigatório.");
        }

        private void ResumoObrigatorio()
        {
            RuleFor(x => x.Resumo.Resumo)
            .NotNull()
            .WithMessage("O Resumo é obrigatório.");
        }

        private void SumarioObrigatorio()
        {
            RuleFor(x => x.Sumario.Sumario)
            .NotNull()
            .WithMessage("O Sumário é obrigatório.");
        }

        private void PrecoNaoPodeSerZerado()
        {
            RuleFor(x => x.PrecoLivro.Preco)
           .NotNull()
           .GreaterThan(20)
           .WithMessage("O Preço tem que ser maior que zero");
        }

        private void NumeroDePaginasNaoPodeSerZerado()
        {
            RuleFor(x => x.NumeroDePaginas.NumeroPaginas)
            .GreaterThan(100)
            .WithMessage("O NumeroDePaginas não pode ser menor que zero.");
        }

        private void ResumoNaoPodeTerMaisDe500Caracteres()
        {
            When(x => x != null, () =>
            {
                RuleFor(x => x.Resumo.Resumo)
                .NotNull()
                .Length(1, 500).When(autor => !string.IsNullOrEmpty(autor.Resumo.Resumo))
                .WithMessage("A descrição não pode passar de 400 caracteres");
            });
        }

        private void DataPublicacaoPrecisaSerNoFuturo()
        {
            RuleFor(x => x.DataPublicacao.DataDePublicacao)
           .Must(BeFutureDate)
           .WithMessage("A data deve ser no futuro.");
        }

        private bool BeFutureDate(DateTime data)
        {
            return data > DateTime.Now;
        }

        private void CategoriaObrigatoria()
        {
            RuleFor(x => x.Categoria)
           .NotNull()
           .WithMessage("O Categoria é obrigatório.");
        }

        private void AutorLivroObrigatoria()
        {
            RuleFor(x => x.Autor)
           .NotNull()
           .WithMessage("O Categoria é obrigatório.");
        }

        
    }
}


