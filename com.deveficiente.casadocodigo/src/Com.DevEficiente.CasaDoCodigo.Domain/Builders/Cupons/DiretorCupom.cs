namespace Com.DevEficiente.CasaDoCodigo.Domain.Builders.Cupons
{
    public class DiretorCupom
    {
        private IConstrutorCupomBuilder _construtorCupomBuilder;

        public DiretorCupom(IConstrutorCupomBuilder construtorCompraBuilder)
        {
            _construtorCupomBuilder = construtorCompraBuilder;
        }

        public void ConstruirCompra(string _Codigo, int _Percentual, DateTime _validade)
        {
            _construtorCupomBuilder.ConstruirCodigo(_Codigo);
            _construtorCupomBuilder.ConstruirPercentual(_Percentual);
            _construtorCupomBuilder.ConstruirValidade(_validade);
        }
    }
}