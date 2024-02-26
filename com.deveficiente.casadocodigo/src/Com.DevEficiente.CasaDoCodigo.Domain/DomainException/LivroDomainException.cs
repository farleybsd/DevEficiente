namespace Com.DevEficiente.CasaDoCodigo.Domain.DomainException
{
    public class LivroDomainException : ValidationException
    {
        public LivroDomainException(IEnumerable<FluentValidation.Results.ValidationFailure> validations) : base(validations)
        {

        }
    }
}
