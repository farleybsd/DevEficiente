using Com.DevEficiente.CasaDoCodigo.Domain.DomainException;
using Com.DevEficiente.CasaDoCodigo.Domain.Validator;
using System.ComponentModel.DataAnnotations;
namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Categoria : EntidadeBase
    {
        public Categoria(string nome)
        {
            Valido();
            Nome = nome;
        }
        public string Nome { get; private set; }
        private void Valido()
        {
            CategoriaValidator validator = new CategoriaValidator();

            var results = validator.Validate(this);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    throw new CategoriaDomainException(failure.ErrorMessage);
                }
            }
        }
    }
}
