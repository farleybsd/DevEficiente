namespace br.com.deveficiente.mercadolivre.Domain.Entity
{
    public class Login : EntidadeBase
    {
        public Instant Instant { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }

        public Login(Email email, Password password)
        {
            Email = email;
            Password = password;
            setInstant();
        }

        public Login()
        {
        }

        public void setInstant()
        {
            Instant = new Instant();
        }
    }
}