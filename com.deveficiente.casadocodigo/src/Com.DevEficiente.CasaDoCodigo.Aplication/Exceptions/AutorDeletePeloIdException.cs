namespace Com.DevEficiente.CasaDoCodigo.Aplication.Exceptions
{
    public class AutorDeletePeloIdException : Exception
    {
        private const string DefaultErrorMessage = "Nao Foi Encontrado o Id Na Base De Dados";
        public AutorDeletePeloIdException(string message = DefaultErrorMessage) : base(message)
        {

        }
    }
}
