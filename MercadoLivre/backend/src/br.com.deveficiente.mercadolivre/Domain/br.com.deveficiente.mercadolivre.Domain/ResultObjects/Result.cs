namespace br.com.deveficiente.mercadolivre.Domain.ResultObjects
{
    public class Result<T> where T : class
    {
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}