namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public class HandlerLogin
    {
        private IBuilderLogin BuilderLogin;
        public HandlerLogin(IBuilderLogin builderLogin)
        {
                BuilderLogin = builderLogin;
        }

        public void builderLogin(string email, string passwordValue, string encryptionKey)
        {
            BuilderLogin.BuilderEmail(email);
            BuilderLogin.BuilderPassword(passwordValue, encryptionKey);
        }
    }
}
