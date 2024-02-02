namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class AutorEditarCommandHandler : IRequestHandler<AutorEditarCommand, AutorResponse>
    {
        private readonly IAutorRepository _autorRepository;

        public AutorEditarCommandHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<AutorResponse> Handle(AutorEditarCommand request, CancellationToken cancellationToken)
        {
            var autor = request.CommandToEntity(request);
            var autorAtualizado = await _autorRepository.GetById(request._id);
            if (autorAtualizado == null)
                throw new AutorEditarDadosException();

            await _autorRepository.Update(autor.Id, autor);

            return new AutorResponse() { Nome = autorAtualizado.Nome, Descricao = autorAtualizado.Descricao, Email = autorAtualizado.Email._email, Instante = autorAtualizado.Instante };
        }
    }
}