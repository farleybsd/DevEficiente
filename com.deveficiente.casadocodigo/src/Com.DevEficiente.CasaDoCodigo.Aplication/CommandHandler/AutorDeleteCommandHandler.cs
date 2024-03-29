﻿namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class AutorDeleteCommandHandler : IRequestHandler<AutorDeleteCommand, string>
    {
        private readonly IAutorRepository _autorRepository;

        public AutorDeleteCommandHandler(IMediator mediator, IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<string> Handle(AutorDeleteCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id))
                throw new AutorDeletePeloIdException();

            await _autorRepository.Remove(request.Id);

            return "Autor deleted successfully!";
        }
    }
}