namespace Com.DevEficiente.CasaDoCodigo.Domain.Builders.Cupons
{
    public class ConstrutorCupom : IConstrutorCupomBuilder
    {
        private Cupom _cupom = new Cupom();

        public void ConstruirCodigo(string _Codigo)
        {
            _cupom.DefinirCodigoCupom(_Codigo);
        }

        public void ConstruirPercentual(int _Percentual)
        {
            _cupom.DefinirPercentualCupom(_Percentual);
        }

        public void ConstruirValidade(DateTime _validade)
        {
            _cupom.DefinirValidadelCupom(_validade);
        }

        public Cupom ObterCupom()
        {
            return _cupom;
        }
    }
}