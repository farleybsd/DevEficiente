namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Pais : EntidadeBase
    {
        public string Nome { get; private set; }

        public Pais(string nome)
        {
            Nome = nome;
        }
    }
}