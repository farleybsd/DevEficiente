namespace Com.DevEficiente.CasaDoCodigo.Aplication.Commands
{
    public class CupomSaveCommand : IRequest<CupomResult>
    {
        public string _Codigo { get; set; }
        public int _Percentual { get; set; }
        public string _Validade { get; set; }

        public CupomSaveCommand(string codigo, int percentual, string validade)
        {
            _Codigo = codigo;
            _Percentual = percentual;
            _Validade = validade;
        }

        public Cupom CommandToEntity(CupomSaveCommand paisSaveCommand)
        {
            return new Cupom(paisSaveCommand._Codigo, paisSaveCommand._Percentual, DateTime.Parse(paisSaveCommand._Validade));
        }
    }
}