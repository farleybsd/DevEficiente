namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class AutorSaveCommandHandler : IRequestHandler<AutorSaveCommand, AutorResponse>
    {
        private readonly IAutorRepository _autorRepository;

        public AutorSaveCommandHandler(IAutorRepository autorRepository)
        {
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