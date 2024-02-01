using Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor;

namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Autor
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Instante Instante { get; private set; }
        public string Descricao  { get; private set; }
    }
}
