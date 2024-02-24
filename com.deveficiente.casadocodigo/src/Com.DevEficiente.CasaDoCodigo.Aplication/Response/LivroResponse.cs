namespace Com.DevEficiente.CasaDoCodigo.Aplication.Response
{
    public class LivroResponse
    {
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Sumario { get; set; }
        public decimal Preco { get; set; }
        public int NumeroPaginas { get; set; }
        public string Isbn { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Categoria { get; set; }
        public string Autor { get; set; }
    }
}