namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class DetalhesDoLivroSiteRequest
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public string Id { get; set; }

        public DetalhesDoLivroSiteCommand RequestToCommand(DetalhesDoLivroSiteRequest request)
        {
            return new DetalhesDoLivroSiteCommand(request.Id);
        }
    }
}