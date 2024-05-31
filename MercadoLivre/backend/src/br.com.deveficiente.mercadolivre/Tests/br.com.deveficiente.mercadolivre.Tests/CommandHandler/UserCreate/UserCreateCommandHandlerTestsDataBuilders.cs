

namespace br.com.deveficiente.mercadolivre.Tests.CommandHandler.UserCreate
{
    public class UserCreateCommandHandlerTestsDataBuilders
    {
        private string Email;
        private string PassWord;

        public UserCreateCommandHandlerTestsDataBuilders()
        {
            Email = "test@example.com";
            PassWord = "password123";
        }

        public UserCreateCommandHandlerTestsDataBuilders WithEmail (string email)
        {
            Email = email;
            return this;
        }

        public UserCreateCommandHandlerTestsDataBuilders WithPassword(string password)
        {
            PassWord = password;
            return this;
        }

        public UserCreateCommand Build()
        {
            return new UserCreateCommand(Email, PassWord);
        }
    }
}
