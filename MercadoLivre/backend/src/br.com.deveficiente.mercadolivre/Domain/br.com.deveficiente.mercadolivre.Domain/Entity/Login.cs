namespace br.com.deveficiente.mercadolivre.Domain.Entity
{
    public class Login : EntidadeBase
    {
        public Instant Instant { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }

        //public Login(Email email, Password password)
        //{
        //    Email = email;
        //    Password = password;
        //    setInstant();
        //}

        public Login()
        {
            setInstant();
        }

        public void setEmail(string email)
        {
            Email = new Email(email);
        }

        public void setPassword(string passwordValue, string encryptionKey)
        {
            Password = new Password( passwordValue, encryptionKey);
        }

        public void setInstant()
        {
            Instant = new Instant();
        }
    }
}