namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Estado : EntidadeBase
    {
        public string IdPais { get; private set; }
        public string NomeEstado { get; private set; }

        public Estado(string idPais, string nomeEstado)
        {
            IdPais = idPais;
            NomeEstado = nomeEstado;
        }
    }
}
