namespace br.com.deveficiente.mercadolivre.Application.Commands
{
    public class UserCreateCommand : IRequest<Result<UserCreateResponse>>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UserCreateCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Login CommandToEntity(UserCreateCommand userCreateCommand)
        {
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);
            var encryptionKey = "ChaveSecreta123";

            var Login = handlerLogin.builderLogin(userCreateCommand.Email, userCreateCommand.Password, encryptionKey);
            return Login;
        }
    }
}