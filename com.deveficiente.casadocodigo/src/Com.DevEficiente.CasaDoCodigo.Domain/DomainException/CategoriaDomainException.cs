namespace Com.DevEficiente.CasaDoCodigo.Domain.DomainException
{
    public class CategoriaDomainException : Exception
    {
        private const string DefaultErrorMessage = "Ja existe uma categoria com esse Nome";

        public CategoriaDomainException(string message = DefaultErrorMessage) : base(message)
        {
        }
    }
}