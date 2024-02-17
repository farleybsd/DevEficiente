namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class CategoriaRequest
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        public CategoriaSaveCommand RequestToCommand(CategoriaRequest categoriaRequest)
        {
            return new CategoriaSaveCommand(categoriaRequest.Nome);
        }
    }
}