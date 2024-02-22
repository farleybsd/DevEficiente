using Com.DevEficiente.CasaDoCodigo.Domain.DomainException;
using Com.DevEficiente.CasaDoCodigo.Domain.Validator;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Autor : EntidadeBase
    {
        public Autor(string nome, Email email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;
            Instante = DateTime.Now;
            Valido();
        }

        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public DateTime Instante { get; private set; }
        public string Descricao { get; private set; }

        private void Valido()
        {
            AutorValidator validator = new AutorValidator();

            var results = validator.Validate(this);

            if (!results.IsValid)
            {
                throw new AutorDomainException((IEnumerable<FluentValidation.Results.ValidationFailure>)results.Errors);

            }
        }
    }
}