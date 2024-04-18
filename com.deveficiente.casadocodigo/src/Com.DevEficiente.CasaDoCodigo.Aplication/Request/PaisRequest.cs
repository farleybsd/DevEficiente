namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class PaisRequest
    {
        [Required(ErrorMessage = "O Nome do pais é obrigatório.")]
        public string NomePais { get; set; }

        public PaisSaveCommand RequestToCommand(PaisRequest paisSaveCommand)
        {
            return new PaisSaveCommand(paisSaveCommand.NomePais);
        }
    }
}