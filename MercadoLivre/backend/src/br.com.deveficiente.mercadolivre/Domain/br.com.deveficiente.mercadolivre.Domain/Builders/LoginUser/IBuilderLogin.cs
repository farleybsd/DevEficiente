namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public interface IBuilderLogin
    {
        Login BuilderLoginAndPassword(string email, string passwordValue, string encryptionKey);
    }
}