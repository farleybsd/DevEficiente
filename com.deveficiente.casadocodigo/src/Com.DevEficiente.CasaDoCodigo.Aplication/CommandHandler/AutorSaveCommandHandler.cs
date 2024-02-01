using Com.DevEficiente.CasaDoCodigo.Aplication.Commands;
using Com.DevEficiente.CasaDoCodigo.Aplication.Response;
using MediatR;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class AutorSaveCommandHandler : IRequestHandler<AutorSaveCommand,AutorResponse>
    {
        private readonly IMediator _mediator;

        public AutorSaveCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<AutorResponse> Handle(AutorSaveCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
