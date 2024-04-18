namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class EstadoRequest
    {
        [Required(ErrorMessage = "O Id do pais é obrigatório.")]
        public string IdPais { get; set; }

        [Required(ErrorMessage = "O Nome do estado é obrigatório.")]
        public string NomeEstado { get; set; }

        public EstadoSaveCommand RequestToCommand(EstadoRequest estadoRequest)
        {
            return new EstadoSaveCommand(estadoRequest.IdPais, estadoRequest.NomeEstado);
        }
    }
}
