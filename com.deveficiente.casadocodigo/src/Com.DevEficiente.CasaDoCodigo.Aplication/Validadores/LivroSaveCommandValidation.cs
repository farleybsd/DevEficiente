using FluentValidation;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Validadores
{
    public class LivroSaveCommandValidation : AbstractValidator<LivroSaveCommand>
    {
        private ILivroRepository _repository;

        public LivroSaveCommandValidation(ILivroRepository repository)
        {
            _repository = repository;
            TituloTemQueSerUnico();
        }

        private void TituloTemQueSerUnico()
        {
            RuleFor(mem => mem.Titulo).MustAsync(async (entity, value, c) => await IsUniqueTitle(value, c))
               .WithMessage("Titulo do Livro Tem Que Ser Unico");
        }

        private async Task<bool> IsUniqueTitle(string titulo, CancellationToken cancellation)
        {
            bool isTituloUnique = await _repository.IsTituloUnique(titulo);

            return isTituloUnique;
        }
    }
}