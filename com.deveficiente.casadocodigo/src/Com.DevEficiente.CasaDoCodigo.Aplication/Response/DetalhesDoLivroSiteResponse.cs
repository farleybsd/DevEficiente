namespace Com.DevEficiente.CasaDoCodigo.Aplication.Response
{
    public class DetalhesDoLivroSiteResponse
    {
        public string Titulo { get; set; }
        public DetalhesAutorSiteResponse Autor { get; set; }
        public string Isbn { get; set; }
        public int NumeroPaginas { get; set; }
        public decimal Preco { get; set; }
        public string Resumo { get; set; }
        public string DataPublicacao { get; set; }
    }
}