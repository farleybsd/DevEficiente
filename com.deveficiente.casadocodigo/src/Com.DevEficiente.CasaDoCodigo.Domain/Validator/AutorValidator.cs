namespace Com.DevEficiente.CasaDoCodigo.Domain.Validator
{
    public class AutorValidator : AbstractValidator<Autor>
    {
        public AutorValidator()
        {
            When(x => x == null, () =>
            {
                RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório.");
            });

            When(x => x == null, () =>
            {
                RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-mail Obrigatorio.");
            });

            When(x => x == null, () =>
            {
                RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição é obrigatória");
            });

            When(x => x != null, () =>
            {
                RuleFor(x => x.Descricao)
                .NotEmpty()
                .Length(1, 100).When(autor => !string.IsNullOrEmpty(autor.Descricao))
                .WithMessage("A descrição não pode passar de 400 caracteres");
            });
        }
    }
}