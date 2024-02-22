namespace Com.DevEficiente.CasaDoCodigo.Domain.DomainException
{
    public class CategoriaDomainException : ValidationException
    {
        public CategoriaDomainException(IEnumerable<FluentValidation.Results.ValidationFailure> validations) : base(validations)
        {
        }
    }
}