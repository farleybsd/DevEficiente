namespace br.com.deveficiente.mercadolivre.Tests.Requets.User
{
    public class UserCreateRequestTests
    {
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
            var userRequest = new UserCreateTestDataBuilders()
                  .WithEmail(email)
                  .WithPassword("123456")
                  .Build();

            // Act
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRequest, null, null);
            bool isValid = Validator.TryValidateObject(userRequest, validationContext, validationResults, true);
            // Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("@semusuario.com")] // Sem usuário
        [InlineData("@emailsemaroba")] // Sem usuário
        [InlineData("@email@sem.ponto")] // Sem usuário
        [InlineData("@semusuario.com")] // Sem usuário
        [InlineData("@semusuario.com")]
        public void loginMustBeInTheInValidEmailFormat(string invalidEmail)
        {
            // Usando o builder para criar um UserCreateRequest com um e-mail inválido
            var userRequest = new UserCreateTestDataBuilders()
                .WithEmail(invalidEmail)
                .WithPassword("123456")
                .Build();

            // Validação
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRequest, null, null);
            bool isValid = Validator.TryValidateObject(userRequest, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Por favor, insira um endereço de e-mail válido."));
        }

        [Fact]
        public void EmailIsRequired()
        {
            // Criar UserCreateRequest sem e-mail
            var userRequest = new UserCreateTestDataBuilders()
                .WithEmail(null) // E-mail ausente
                .WithPassword("123456")
                .Build();

            // Validação
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRequest, null, null);
            bool isValid = Validator.TryValidateObject(userRequest, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage == "e-mail é obrigatório.");
        }

        [Fact]
        public void EmailIsRequiredStringEmpity()
        {
            // Criar UserCreateRequest sem e-mail
            var userRequest = new UserCreateTestDataBuilders()
                .WithEmail(string.Empty)
                .WithPassword("123456")
                .Build();

            // Validação
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRequest, null, null);
            bool isValid = Validator.TryValidateObject(userRequest, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage == "e-mail é obrigatório.");
        }

        [Fact]
        public void EmailIsRequiredUsequotationmarks()
        {
            // Criar UserCreateRequest sem e-mail
            var userRequest = new UserCreateTestDataBuilders()
                .WithEmail("")
                .WithPassword("123456")
                .Build();

            // Validação
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRequest, null, null);
            bool isValid = Validator.TryValidateObject(userRequest, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage == "e-mail é obrigatório.");
        }

        [Fact]
        public void PasswordIsRequiredUseNull()
        {
            // Criar UserCreateRequest sem e-mail
            var userRequest = new UserCreateTestDataBuilders()
                .WithEmail("email@example.com") // E-mail ausente
                .WithPassword(null)
                .Build();

            // Validação
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRequest, null, null);
            bool isValid = Validator.TryValidateObject(userRequest, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage == "Password é obrigatória");
        }

        [Fact]
        public void PasswordIsRequiredUseStringEmpty()
        {
            // Criar UserCreateRequest sem e-mail
            var userRequest = new UserCreateTestDataBuilders()
                .WithEmail("email@example.com") // E-mail ausente
                .WithPassword(string.Empty)
                .Build();

            // Validação
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRequest, null, null);
            bool isValid = Validator.TryValidateObject(userRequest, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage == "Password é obrigatória");
        }

        [Fact]
        public void PasswordIsRequiredUsequotationmarks()
        {
            // Criar UserCreateRequest sem e-mail
            var userRequest = new UserCreateTestDataBuilders()
                .WithEmail("") // E-mail ausente
                .WithPassword(string.Empty)
                .Build();

            // Validação
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(userRequest, null, null);
            bool isValid = Validator.TryValidateObject(userRequest, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage == "Password é obrigatória");
        }
    }
}