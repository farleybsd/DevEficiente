namespace Com.DevEficiente.CasaDoCodigo.Domain.Builders.Cupons
{
    public interface IConstrutorCupomBuilder
    {
        void ConstruirCodigo(string _Codigo);

        void ConstruirPercentual(int _Percentual);

        void ConstruirValidade(DateTime _validade);

        Cupom ObterCupom();
    }
}