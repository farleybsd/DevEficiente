namespace Com.DevEficiente.CasaDoCodigo.Domain.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            //RuleFor(x => x.Nome)
            //    .NotNull()
            //    .WithMessage("Nome Nao pode Ser Vazio");

            When(x => x == null, () =>
            {
                RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório.");
            });
        }
    }
}