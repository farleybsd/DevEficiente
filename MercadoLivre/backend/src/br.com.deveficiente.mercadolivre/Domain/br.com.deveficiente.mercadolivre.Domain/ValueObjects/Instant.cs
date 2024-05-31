namespace br.com.deveficiente.mercadolivre.Domain.ValueObjects
{
    public class Instant
    {
        public string CreationDate { get; private set; }

        public Instant()
        {
            CreationDate = DateTimeOffset.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}