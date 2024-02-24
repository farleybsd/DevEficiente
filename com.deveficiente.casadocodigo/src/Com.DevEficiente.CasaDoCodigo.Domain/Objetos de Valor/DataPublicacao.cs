namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    public class DataPublicacao
    {
        public DateTime DataDePublicacao { get; private set; }

        public DataPublicacao(DateTime dataDePublicacao)
        {
            DataDePublicacao = dataDePublicacao;
        }
    }
}