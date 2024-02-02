namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class AutorByIdRequest
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public string Id { get; set; }

        public AutorByIdQueryCommand RequestToCommand(AutorByIdRequest request)
        {
            return new AutorByIdQueryCommand(request.Id);
        }
    }
}