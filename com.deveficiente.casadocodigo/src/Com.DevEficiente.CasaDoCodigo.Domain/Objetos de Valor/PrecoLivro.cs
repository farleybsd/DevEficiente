namespace Com.DevEficiente.CasaDoCodigo.Domain.Objetos_de_Valor
{
    public class PrecoLivro
    {
        public decimal Preco { get; private set; }

        public PrecoLivro(decimal preco)
        {
            Preco = preco;
        }
    }
}
