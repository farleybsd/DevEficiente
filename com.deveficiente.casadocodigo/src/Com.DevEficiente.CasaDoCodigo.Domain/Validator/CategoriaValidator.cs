﻿namespace Com.DevEficiente.CasaDoCodigo.Domain.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome Nao pode Ser Vazio");
        }
    }
}