namespace Com.DevEficiente.CasaDoCodigo.Aplication.Exceptions
{
    public class CategoriaSaveException : Exception
    {
        private const string DefaultErrorMessage = "Nome da Categoria ja esta cadastrado Na Base De Dados";

        public CategoriaSaveException(string message = DefaultErrorMessage) : base(message)
        {
        }
    }
}