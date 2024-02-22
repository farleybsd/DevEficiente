namespace Com.DevEficiente.CasaDoCodigo.Domain.Validator
{
    public class AutorValidator : AbstractValidator<Autor>
    {
        public AutorValidator()
        {
            RuleFor(x => x.Nome)
            .NotNull()
            .WithMessage("O Nome é obrigatório.");

            RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("E-mail Obrigatorio.");

            RuleFor(x => x.Descricao)
            .NotNull()
            .WithMessage("A descrição é obrigatória");

            When(x => x != null, () =>
            {
                RuleFor(x => x.Descricao)
                .NotNull()
                .Length(1, 100).When(autor => !string.IsNullOrEmpty(autor.Descricao))
                .WithMessage("A descrição não pode passar de 400 caracteres");
            });
        }
    }
}