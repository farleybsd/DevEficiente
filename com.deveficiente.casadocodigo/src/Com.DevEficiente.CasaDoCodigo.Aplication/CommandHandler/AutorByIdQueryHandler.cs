﻿namespace Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler
{
    public class AutorByIdQueryHandler : IRequestHandler<AutorByIdQueryCommand, AutorByIdQueryResult>
    {
        private readonly IAutorRepository _autorRepository;

        public AutorByIdQueryHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<AutorByIdQueryResult> Handle(AutorByIdQueryCommand request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.GetById(request.Id);

            if (autor == null)
                throw new AutorByIdQueryException();

            return new AutorByIdQueryResult()
            {
                Nome = autor.Nome,
                Descricao = autor.Descricao,
                Email = autor.Email._email,
                Instante = autor.Instante
            };
        }
    }
}