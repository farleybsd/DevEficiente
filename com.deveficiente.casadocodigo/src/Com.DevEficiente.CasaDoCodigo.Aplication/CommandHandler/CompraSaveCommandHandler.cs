using Com.DevEficiente.CasaDoCodigo.Domain.Builders;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class CompraSaveCommandHandler : IRequestHandler<CompraSaveCommand, CompraResult>
    {
        private readonly ICompraRepository _repository;

        public CompraSaveCommandHandler(ICompraRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompraResult> Handle(CompraSaveCommand request, CancellationToken cancellationToken)
        {
            var compraSaveCommand = request.CommandToEntity(request);

            var consturorCompra = new ConstrutorCompra();
            var diretorCompra = new DiretorCompra(consturorCompra);

            diretorCompra.ConstruirCompra(request.Email, request.nome, request.sobrenome, request.documento, request.endereco, request.complemento,
                                          request.cidade, request.cep, request.pais, request.estado, request.telefone);

            var compraSave = consturorCompra.ObterCompra();

            await _repository.Add(compraSave);

            return new CompraResult()
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
                cep = request.cep
            };
        }
    }
}