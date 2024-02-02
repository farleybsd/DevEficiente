namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class AutorEditarRequest
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail Obrigatorio")]
        [EmailAddress(ErrorMessage = "O email tem que ter formato válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(400, MinimumLength = 1, ErrorMessage = "A descrição não pode passar de 400 caracteres")]
        public string Descricao { get; set; }

        public AutorEditarCommand RequestToCommand(AutorEditarRequest autor)
        {
            return new AutorEditarCommand(autor.Nome, autor.Email, autor.Descricao, autor.Id);
        }
    }
}