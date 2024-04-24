namespace Com.DevEficiente.CasaDoCodigo.Domain.Entidades
{
    public class Cupom : EntidadeBase
    {
        public string _Codigo { get; private set; }
        public int _Percentual { get; private set; }
        public DateTime _Validade { get; private set; }

        public Cupom(string codigo, int percentual, DateTime validade)
        {
            _Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo), "O codigo não pode ser nulo");
            _Percentual = percentual > 0 ? percentual : throw new ArgumentException("O percentual deve ser maior que zero.", nameof(percentual));
            _Validade = validade != DateTime.MinValue ? validade : throw new ArgumentNullException(nameof(validade), "A data de validade não pode ser nula."); ;
        }

        public Cupom()
        {
        }

        public void DefinirCodigoCupom(string _codigo)
        {
            _Codigo = _codigo;
        }

        public void DefinirPercentualCupom(int percentual)
        {
            _Percentual = percentual;
        }

        public void DefinirValidadelCupom(DateTime _validade)
        {
            _Validade = _validade;
        }

        public bool CupomEstaValido()
        {
            return DateTime.Now < _Validade;
        }
    }
}