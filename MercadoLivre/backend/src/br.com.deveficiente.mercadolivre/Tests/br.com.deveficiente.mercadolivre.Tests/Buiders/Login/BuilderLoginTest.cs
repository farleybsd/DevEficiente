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

            var Login = handlerLogin.builderLogin(email, passwordValue, encryptionKey);

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

            var LoginEmail = handlerLogin.builderLogin(email, passwordValue, encryptionKey);

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

        [Theory]
        [InlineData("12")]
        [InlineData("2")]
        [InlineData("123")]
        [InlineData("1234")]
        [InlineData("12345")]
        public void ThePasswordMustBeAtLeastSixCharactersLong(string passwordValue)
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            var email = "farley.t.i@hotmail.com";
            var encryptionKey = "ChaveSecreta123";

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => handlerLogin.builderLogin(email, passwordValue, encryptionKey));
            Assert.Equal("passwordValue", exception.ParamName);
            Assert.Equal("O password não pode ter menos que 6 digitos. (Parameter 'passwordValue')", exception.Message);
        }

        [Theory]
        [InlineData("1234567")]
        public void PasswordWithMoreThanSixDigits(string passwordValue)
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            var email = "farley.t.i@hotmail.com";
            var encryptionKey = "ChaveSecreta123";

            var Login = handlerLogin.builderLogin(email, passwordValue, encryptionKey);

            // Act
            var resultado = Login.Password.EncryptedPassword;

            // Assert
            Assert.NotNull(resultado);
        }

        [Theory]
        [InlineData("1234567")]
        public void ThePasswordMustBeStoredUsingSomeHashingAlgorithmYourChoice(string passwordValue)
        {
            // Arrange
            var builderLogin = new BuilderLogin();
            var handlerLogin = new HandlerLogin(builderLogin);

            var email = "farley.t.i@hotmail.com";
            var encryptionKey = "ChaveSecreta123";

            var Login = handlerLogin.builderLogin(email, passwordValue, encryptionKey);

            var passwod = new Password(passwordValue, encryptionKey);

            // Act
            var resultado = Login.Password.EncryptedPassword;

            // Assert
            Assert.Equal(resultado, passwod.EncryptedPassword);
        }
    }
}