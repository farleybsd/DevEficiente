using Com.DevEficiente.CasaDoCodigo.Domain.Builders;
using Com.DevEficiente.CasaDoCodigo.Domain.Builders.Cupons;
using MongoDB.Driver;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class CupomSaveCommandHandler : IRequestHandler<CupomSaveCommand, CupomResult>
    {
        private readonly ICupomRepository _repository;

        public CupomSaveCommandHandler(ICupomRepository repository)
        {
            _repository = repository;
        }

        public async Task<CupomResult> Handle(CupomSaveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cupomSaveCommand = request.CommandToEntity(request);
                var consturorCupom = new ConstrutorCupom();
                var diretorCupom = new DiretorCupom(consturorCupom);
               

                diretorCupom.ConstruirCompra(cupomSaveCommand._Codigo, cupomSaveCommand._Percentual, cupomSaveCommand._Validade);

                var cupomSave = consturorCupom.ObterCupom();

                await _repository.Add(cupomSave);

                return new CupomResult()
                {
                    _Codigo = cupomSave._Codigo,
                    _Percentual = cupomSave._Percentual,
                    _Validade = cupomSave._Validade.ToString("yyyy-MM-dd")
                };
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                throw new ValidationException("O Cupom já existe.");
            }
        }
    }
}