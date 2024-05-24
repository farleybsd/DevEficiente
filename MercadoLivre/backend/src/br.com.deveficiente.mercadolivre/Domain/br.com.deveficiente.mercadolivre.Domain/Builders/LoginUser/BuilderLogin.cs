using br.com.deveficiente.mercadolivre.Domain.Entity;
using br.com.deveficiente.mercadolivre.Domain.ValueObjects;

namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public class BuilderLogin : IBuilderLogin
    {
        private Login _Login = new Login();
        public void BuilderEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "O email não pode ser nulo ou vazio.");

            Email loginEmail = new Email(email);
            _Login.setEmail(loginEmail);
        }

        public void BuilderPassword(string passwordValue, string encryptionKey)
        {
            if (string.IsNullOrWhiteSpace(passwordValue))
                throw new ArgumentNullException(nameof(passwordValue), "O password não pode ser nulo ou vazio.");

            if (passwordValue.Length < 6)
                throw new ArgumentNullException(nameof(passwordValue), "O password não pode ter menos que 6 digitos.");

            Password loginPassword = new Password(passwordValue, encryptionKey);
            _Login.setPassword(loginPassword);
        }

        public Login GetLogin()
        {
            return _Login;
        }
    }
}
