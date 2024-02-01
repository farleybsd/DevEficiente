using Com.DevEficiente.CasaDoCodigo.Aplication.Commands;
using Com.DevEficiente.CasaDoCodigo.Aplication.Response;
using Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio;
using MediatR;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class AutorSaveCommandHandler : IRequestHandler<AutorSaveCommand,AutorResponse>
    {
        private readonly IMediator _mediator;
        private readonly IAutorRepository _autorRepository;
        public AutorSaveCommandHandler(IMediator mediator,
                                       IAutorRepository autorRepository)
        {
            _mediator = mediator;
            _autorRepository = autorRepository;
        }

        public async Task<AutorResponse> Handle(AutorSaveCommand request, CancellationToken cancellationToken)
        {
            var AutorSave = request.CommandToEntity(request);
            
            await _autorRepository.Add(AutorSave);

            return new AutorResponse()
            {
                Nome = request.Nome,
                Email = request.Email,
                Descricao = request.Descricao,
                Instante = AutorSave.Instante
            };
        }
    }
}
