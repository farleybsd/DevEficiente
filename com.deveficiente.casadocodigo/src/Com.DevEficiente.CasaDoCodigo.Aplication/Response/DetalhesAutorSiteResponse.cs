namespace Com.DevEficiente.CasaDoCodigo.Aplication.Response
{
    public class DetalhesAutorSiteResponse
    {
        public string Autor { get; set; }

        public DetalhesAutorSiteResponse(string autor)
        {
            Autor = autor;
        }
    }
}