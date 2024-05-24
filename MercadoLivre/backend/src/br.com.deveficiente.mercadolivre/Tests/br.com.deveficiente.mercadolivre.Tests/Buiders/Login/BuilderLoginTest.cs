using br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser;
using br.com.deveficiente.mercadolivre.Domain.ValueObjects;
using System.Globalization;

namespace br.com.deveficiente.mercadolivre.Tests.Buiders.Login
{
    public class BuilderLoginTest
    {
        [Fact]
        public void momentOfRegistrationLoginAndPassword()
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            var email = "farley.t.i@hotmail.com";
            var passwordValue = "MinhaSenha123";
            var encryptionKey = "ChaveSecreta123";

            handlerLogin.builderLogin(email, passwordValue, encryptionKey);

            var Login = builderLogin.GetLogin();

            // Act
            var resultado = Login.Instant.CreationDate;

            // Assert
            Assert.Equal(DateTimeOffset.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), resultado);
        }

        [Fact]
        public void loginCannotbeblank()
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            var email = string.Empty;
            var passwordValue = "MinhaSenha123";
            var encryptionKey = "ChaveSecreta123";

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => handlerLogin.builderLogin(email, passwordValue, encryptionKey));
            Assert.Equal("email", exception.ParamName);
            Assert.Equal("O email não pode ser nulo ou vazio. (Parameter 'email')", exception.Message);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void loginCannotbeNull(string email)
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            
            var passwordValue = "MinhaSenha123";
            var encryptionKey = "ChaveSecreta123";

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => handlerLogin.builderLogin(email, passwordValue, encryptionKey));
            Assert.Equal("email", exception.ParamName);
            Assert.Equal("O email não pode ser nulo ou vazio. (Parameter 'email')", exception.Message);

        }

        [Fact]
        public void loginCannotbeDoubleQuotes()
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);


            var passwordValue = "MinhaSenha123";
            var encryptionKey = "ChaveSecreta123";

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => handlerLogin.builderLogin("", passwordValue, encryptionKey));
            Assert.Equal("email", exception.ParamName);
            Assert.Equal("O email não pode ser nulo ou vazio. (Parameter 'email')", exception.Message);

        }

        [Theory]
        [InlineData("emailsemaroba")] // Sem o símbolo @
        [InlineData("email@semdominio")] // Sem o domínio
        [InlineData("email.com")] // Sem o nome de usuário
        [InlineData("email@com")] // Domínio inválido
        [InlineData("email@com.")] // Domínio inválido
        [InlineData("email@com.123")] // Domínio inválido
        [InlineData("email@-invalido.com")] // Domínio inválido
        [InlineData("email@invalido-.com")] // Domínio inválido
        [InlineData("email@[123.123.123.123]")] // Domínio inválido
        [InlineData("email@123.123.123.123")] // Domínio inválido
        [InlineData("email@[IPv6:2001:db8::1]")] // Domínio inválido
        [InlineData("email@example..com")] // Ponto extra no domínio
        [InlineData("email.@example.com")] // Ponto no início do nome de usuário
        [InlineData(".email@example.com")] // Ponto no início do nome de domínio
        [InlineData("email@example.com (Joe Smith)")] // Caracteres especiais não permitidos
        [InlineData("email@example")] // TLD ausente
        [InlineData("email@example..com")] // Ponto duplo no domínio
        [InlineData("email@-example.com")] // Hífen no início do nome de domínio
        [InlineData("email@example-.com")] // Hífen no final do nome de domínio
        [InlineData("email@example.com.")] // Ponto no final do nome de domínio
        public void loginMustBeInTheInValidEmailFormat(string email)
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            var passwordValue = "MinhaSenha123";
            var encryptionKey = "ChaveSecreta123";
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => handlerLogin.builderLogin("", passwordValue, encryptionKey));
            Assert.Equal("email", exception.ParamName);
            Assert.Equal("O email não pode ser nulo ou vazio. (Parameter 'email')", exception.Message);
        }

        [Theory]
        [InlineData("email@example.com")] // Formato padrão com um domínio válido
        [InlineData("email.lastname@example.com")] // E-mail com sobrenome no domínio
        [InlineData("firstname+lastname@example.com")] // E-mail com sinal de adição
        [InlineData("1234567890@example.com")] // E-mail com apenas números no nome de usuário
        [InlineData("email@subdomain.example.com")] // E-mail com subdomínio
        [InlineData("email@123.123.123.123")] // E-mail com IP no lugar do nome de domínio
        [InlineData("\"email\"@example.com")] // E-mail com aspas no nome de usuário
        [InlineData("email@[123.123.123.123]")] // E-mail com IP entre colchetes
        [InlineData("email@example.123")] // E-mail com números no nome de domínio
        [InlineData("email@example.museum")] // E-mail com TLD incomum
        public void loginMustBeInTheValidEmailFormat(string email)
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            var passwordValue = "MinhaSenha123";
            var encryptionKey = "ChaveSecreta123";
            handlerLogin.builderLogin(email, passwordValue, encryptionKey);

            var LoginEmail = builderLogin.GetLogin();

            // Act
            var resultado = LoginEmail.Email.Address;

            // Assert
            Assert.NotNull(resultado);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThePasswordCannotBeBlankOrNull(string passwordValue)
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            var email = "farley.t.i@hotmail.com";
            var encryptionKey = "ChaveSecreta123";

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => handlerLogin.builderLogin(email, passwordValue, encryptionKey));
            Assert.Equal("passwordValue", exception.ParamName);
            Assert.Equal("O password não pode ser nulo ou vazio. (Parameter 'passwordValue')", exception.Message);

        }
    }
}
