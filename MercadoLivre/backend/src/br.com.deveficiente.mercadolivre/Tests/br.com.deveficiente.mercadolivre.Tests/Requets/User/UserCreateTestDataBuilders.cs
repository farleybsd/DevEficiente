

namespace br.com.deveficiente.mercadolivre.Tests.Requets.User
{
    public class UserCreateTestDataBuilders
    {
        private string _email;
        private string _password;

        public UserCreateTestDataBuilders()
        {
            // Valores padrão para os campos
            _email = "test@example.com";
            _password = "123456";
        }

        public UserCreateTestDataBuilders WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public UserCreateTestDataBuilders WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public UserCreateRequest Build()
        {
            return new UserCreateRequest
            {
                Email = _email,
                Password = _password
            };
        }
    }
}
