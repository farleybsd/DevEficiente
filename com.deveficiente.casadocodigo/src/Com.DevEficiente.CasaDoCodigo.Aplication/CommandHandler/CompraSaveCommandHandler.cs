using Com.DevEficiente.CasaDoCodigo.Domain.Builders;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class CompraSaveCommandHandler : IRequestHandler<CompraSaveCommand, CompraResult>
    {
        private readonly ICompraRepository _repository;
        private readonly ICupomRepository _cupomRepository;
        public CompraSaveCommandHandler(ICompraRepository repository, ICupomRepository cupomRepository)
        {
            _repository = repository;
            _cupomRepository = cupomRepository;
        }

        public async Task<CompraResult> Handle(CompraSaveCommand request, CancellationToken cancellationToken)
        {
            var compraSaveCommand = request.CommandToEntity(request);

            var consturorCompra = new ConstrutorCompra();
            var diretorCompra = new DiretorCompra(consturorCompra);

            diretorCompra.ConstruirCompra(request.Email, request.nome, request.sobrenome, request.documento, request.endereco, request.complemento,
                                          request.cidade, request.cep, request.pais, request.estado, request.telefone);

            var compraSave = consturorCompra.ObterCompra();

            var cupom = await _cupomRepository.GetById(request.IdCupom);

            compraSave.DefinirCupomDaCompra(cupom);

            await _repository.Add(compraSave);

            var compraResult = new CompraResult()
            {
                email = request.Email,
                nome = request.nome,
                sobrenome = request.sobrenome,
                documento = request.documento,
                endereco = request.endereco,
                complemento = request.complemento,
                cidade = request.cidade,
                pais = request.pais,
                estado = request.estado,
                telefone = request.telefone,
                cep = request.cep,
            };

            if (cupom.CupomEstaValido())
            {
                compraResult._Codigo = cupom._Codigo;
                compraResult._Percentual = cupom._Percentual;
                compraResult._Validade = cupom._Validade.ToString("dd/MM/yyyy");
            }
            else
            {
                compraResult._Codigo = null;
                compraResult._Percentual = 0;
                compraResult._Validade = null;
            }

            return compraResult;
        }
    }
}