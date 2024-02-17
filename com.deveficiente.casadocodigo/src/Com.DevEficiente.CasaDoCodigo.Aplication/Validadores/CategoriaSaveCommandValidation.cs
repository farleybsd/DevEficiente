using FluentValidation;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Validadores
{
    public class CategoriaSaveCommandValidation : AbstractValidator<CategoriaSaveCommand>
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaSaveCommandValidation(ICategoriaRepository repository)
        {
            _repository = repository;

            RuleFor(mem => mem.Nome).MustAsync(async (entity, value, c) => await IsUniqueUsername(value, c))
               .WithMessage("Nome da Categoria Tem Que Ser Unico");
        }

        private async Task<bool> IsUniqueUsername(string nome, CancellationToken cancellationToken)
        {
            var NomeCategoriaExiste = await _repository.BuscarCategoriaPorNome(nome);

            if (NomeCategoriaExiste != null) return false;

            return true;
        }
    }
}