namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    public class ResumoLivro
    {
        public string Resumo { get; private set; }

        public ResumoLivro(string resumo)
        {
            Resumo = resumo;
        }
    }
}