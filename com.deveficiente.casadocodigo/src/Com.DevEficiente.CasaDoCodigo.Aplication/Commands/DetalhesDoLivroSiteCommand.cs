namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class DetalhesDoLivroSiteCommand : IRequest<DetalhesDoLivroSiteResponse>
    {
        public DetalhesDoLivroSiteCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}