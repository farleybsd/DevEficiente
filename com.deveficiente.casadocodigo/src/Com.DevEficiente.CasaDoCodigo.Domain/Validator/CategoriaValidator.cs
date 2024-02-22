namespace Com.DevEficiente.CasaDoCodigo.Domain.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(x => x.Nome)
            .NotNull()
            .WithMessage("O Nome é obrigatório.");
        }
    }
}