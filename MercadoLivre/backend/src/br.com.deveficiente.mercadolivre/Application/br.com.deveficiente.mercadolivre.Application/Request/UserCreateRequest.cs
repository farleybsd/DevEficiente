using br.com.deveficiente.mercadolivre.Application.Commands;
using System.ComponentModel.DataAnnotations;

namespace br.com.deveficiente.mercadolivre.Application.Request
{
    public class UserCreateRequest
    {
        [Required(ErrorMessage = "e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é obrigatória")]
        [StringLength(6, MinimumLength = 1, ErrorMessage = "O Password não pode passar de 6 caracteres")]
        public string Password { get; set; }

        public UserCreateCommand RequestToCommand(UserCreateRequest userCreateRequest)
        {
            return new UserCreateCommand(userCreateRequest.Email, userCreateRequest.Password);
        }
    }
}
