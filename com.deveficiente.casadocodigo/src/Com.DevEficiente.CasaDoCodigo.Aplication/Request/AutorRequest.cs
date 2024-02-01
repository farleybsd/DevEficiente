using Com.DevEficiente.CasaDoCodigo.Aplication.Commands;
using Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor;
using System.ComponentModel.DataAnnotations;

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

        public AutorSaveCommand toCommand(AutorRequest autor)
        {
            return new AutorSaveCommand(autor.Nome,autor.Email,autor.Descricao);
        }
    }
}
