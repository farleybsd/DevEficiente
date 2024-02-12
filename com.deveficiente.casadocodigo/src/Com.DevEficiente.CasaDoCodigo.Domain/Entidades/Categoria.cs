using Com.DevEficiente.CasaDoCodigo.Domain.DomainException;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Categoria : EntidadeBase
    {
        public Categoria(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new CategoriaDomainException();
            }

            Nome = nome;
        }
        public string Nome { get; private set; }
    }
}
