using Com.DevEficiente.CasaDoCodigo.Domain.DomainException;
using Com.DevEficiente.CasaDoCodigo.Domain.Validator;
using FluentValidation;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Categoria : EntidadeBase
    {
        public Categoria(string nome)
        {
            Nome = nome;
            Valido();
        }

        public string Nome { get; private set; }

        private void Valido()
        {
            CategoriaValidator validator = new CategoriaValidator();

            var results = validator.Validate(this);

            if (!results.IsValid)
            {
                throw new CategoriaDomainException((IEnumerable<FluentValidation.Results.ValidationFailure>)results.Errors);

            }
        }
    }
}