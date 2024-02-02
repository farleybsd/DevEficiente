namespace Com.DevEficiente.CasaDoCodigo.Aplication.Exceptions
{
    public class AutorEditarDadosException : Exception
    {
        private const string DefaultErrorMessage = "Nao Foi Encontrado o Id Na Base De Dados";
        public AutorEditarDadosException(string message = DefaultErrorMessage) : base(message)
        {
            
        }
    }
}
