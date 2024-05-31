namespace br.com.deveficiente.mercadolivre.Domain.Entity
{
    public class Login : EntidadeBase
    {
        public Instant Instant { get; set; }
        public Email Email { get; private set; }
        public Password Password { get; set; }

        public Login(Email email, Password password)
        {
            Email = email;
            Password = password;
            Instant = new Instant();
        }

        public Login()
        {
        }
    }
}