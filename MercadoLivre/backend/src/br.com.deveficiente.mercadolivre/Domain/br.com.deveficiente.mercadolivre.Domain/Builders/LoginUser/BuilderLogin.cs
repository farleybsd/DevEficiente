namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public class BuilderLogin : IBuilderLogin
    {
        private Login _Login = new Login();

        public Login BuilderLoginAndPassword(string email, string passwordValue, string encryptionKey)
        {
            EmailNotNull(email);
            PasswordNotNull(passwordValue);
            PasswordAtleastSixCharacters(passwordValue);
            var login = new Login();
            login.setEmail(email);
            login.setPassword(passwordValue, encryptionKey);
            return login;
        }

        private void EmailNotNull(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "O email não pode ser nulo ou vazio.");
        }

        private void PasswordAtleastSixCharacters(string passwordValue)
        {
            if (passwordValue.Length < 6)
                throw new ArgumentNullException(nameof(passwordValue), "O password não pode ter menos que 6 digitos.");
        }

        private void PasswordNotNull(string passwordValue)
        {
            if (string.IsNullOrWhiteSpace(passwordValue))
                throw new ArgumentNullException(nameof(passwordValue), "O password não pode ser nulo ou vazio.");
        }
    }
}