using Com.DevEficiente.CasaDoCodigo.Aplication.DataNotations;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class CupomRequest
    {
        [Required(ErrorMessage = "Cupom é obrigatório.")]
        public string _Codigo { get; set; }

        [Required(ErrorMessage = "O percentual é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O percentual deve ser um valor positivo.")]
        public int _Percentual { get; set; }

        [DateTimeFuturo(ErrorMessage = "Data que vai entrar no ar precisa ser no futuro")]
        public string _Validade { get; set; }

        public CupomSaveCommand RequestToCommand(CupomRequest cupomRequest)
        {
            return new CupomSaveCommand(cupomRequest._Codigo, cupomRequest._Percentual, cupomRequest._Validade);
        }
    }
}