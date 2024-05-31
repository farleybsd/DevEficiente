namespace br.com.deveficiente.mercadolivre.Domain.ValueObjects
{
    public class Email
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private string _address;

        public string Address => _address;

        public Email(string address)
        {
            if (!IsValidEmail(address))
            {
                throw new ArgumentException("Invalid email format", nameof(address));
            }
            _address = address;
        }
        // Necessário para o EF Core poder instanciar a entidade
        private Email()
        { }

        private static bool IsValidEmail(string email)
        {
            return EmailRegex.IsMatch(email);
        }
    }
}