namespace Com.DevEficiente.CasaDoCodigo.Domain.DomainException
{
    public class AutorDomainException : ValidationException
    {
        public AutorDomainException(IEnumerable<FluentValidation.Results.ValidationFailure> validations) : base(validations)
        {
        }
    }
}