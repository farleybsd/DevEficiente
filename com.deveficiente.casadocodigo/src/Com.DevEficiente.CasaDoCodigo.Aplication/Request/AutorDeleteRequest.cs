namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class AutorDeleteRequest
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public string Id { get; set; }

        public AutorDeleteCommand RequestToCommand(AutorDeleteRequest request)
        {
            return new AutorDeleteCommand(request.Id);
        }
    }
}
