

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class AutorRequest
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail Obrigatorio")]
        [EmailAddress(ErrorMessage = "O email tem que ter formato válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(400, MinimumLength = 1, ErrorMessage = "A descrição não pode passar de 400 caracteres")]
        public string Descricao { get; set; }

        public AutorSaveCommand RequestToCommand(AutorRequest autor)
        {
            return new AutorSaveCommand(autor.Nome,autor.Email,autor.Descricao);
        }
    }
}
