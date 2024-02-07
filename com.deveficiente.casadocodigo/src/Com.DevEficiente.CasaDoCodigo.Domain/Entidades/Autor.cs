namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Autor : EntidadeBase
    {
        public Autor(string nome, Email email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;
            Instante = DateTime.Now;
        }

        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public DateTime Instante { get; private set; }
        public string Descricao { get; private set; }
    }
}