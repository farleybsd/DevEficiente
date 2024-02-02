namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class BuscarTodosAutoresCommandHandler : IRequestHandler<BuscarTodosAutoresCommand, IEnumerable<AutorResponse>>
    {
        private readonly IAutorRepository _autorRepository;

        public BuscarTodosAutoresCommandHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<IEnumerable<AutorResponse>> Handle(BuscarTodosAutoresCommand request, CancellationToken cancellationToken)
        {
            var listAutorResponse = new List<AutorResponse>();
            var listAutores = await _autorRepository.GetAll();

            foreach (var item in listAutores)
            {
                listAutorResponse.Add(new AutorResponse() {Nome= item.Nome,Email = item.Email._email,Descricao=item.Descricao } );
            }
            return listAutorResponse;
        }
    }
}
