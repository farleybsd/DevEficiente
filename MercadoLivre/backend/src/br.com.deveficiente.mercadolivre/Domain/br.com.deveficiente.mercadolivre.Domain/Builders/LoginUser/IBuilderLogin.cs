using br.com.deveficiente.mercadolivre.Domain.Entity;

namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public interface IBuilderLogin
    {
        void BuilderEmail(string email);

        void BuilderPassword(string passwordValue, string encryptionKey);

        Login GetLogin();
    }
}