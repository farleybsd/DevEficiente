using br.com.deveficiente.mercadolivre.Domain.ValueObjects;

namespace br.com.deveficiente.mercadolivre.Domain.Entity
{
    public class Login : EntidadeBase
    {
        public Instant Instant { get; set; }
        public Email Email { get; private set; }
        public Password Password { get; set; }

        public Login()
        {
            Instant = new Instant();
        }

        public void setEmail(Email email)
        {
            Email = email;
        }

        public void setPassword(Password password)
        {
            Password = password;
        }
    }
}