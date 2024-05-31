

namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public class HandlerLogin
    {
        private IBuilderLogin BuilderLogin;

        public HandlerLogin(IBuilderLogin builderLogin)
        {
            BuilderLogin = builderLogin;
        }

        public Login builderLogin(string email, string passwordValue, string encryptionKey)
        {
            
            return BuilderLogin.BuilderLoginAndPassword(email,passwordValue, encryptionKey);
        }
    }
}