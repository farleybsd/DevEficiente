namespace Com.DevEficiente.CasaDoCodigo.Aplication.Exceptions
{
    public class LivroSaveException : Exception
    {
        private const string DefaultErrorMessage = "O Titulo ja esta cadastrado Na Base De Dados";

        public LivroSaveException(string message = DefaultErrorMessage) : base(message)
        {
        }
    }
}