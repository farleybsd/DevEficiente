namespace Com.DevEficiente.CasaDoCodigo.Aplication.Exceptions
{
    public class AutorByIdQueryException : Exception
    {
        private const string DefaultErrorMessage = "Nao Foi Encontrado o Id Na Base De Dados";

        public AutorByIdQueryException(string message = DefaultErrorMessage) : base(message)
        {
        }
    }
}