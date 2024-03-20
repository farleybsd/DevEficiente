namespace Com.DevEficiente.CasaDoCodigo.Aplication.Exceptions
{
    public class LivroByIdQueryException : Exception
    {
        private const string DefaultErrorMessage = "Nao Foi Encontrado o Id Na Base De Dados";

        public LivroByIdQueryException(string message = DefaultErrorMessage) : base(message)
        {
        }
    }
}