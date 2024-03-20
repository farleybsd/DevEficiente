namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class LivroByIdRequest
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public string Id { get; set; }

        public LivroByIdQueryCommand RequestToCommand(LivroByIdRequest request)
        {
            return new LivroByIdQueryCommand(request.Id);
        }
    }
}