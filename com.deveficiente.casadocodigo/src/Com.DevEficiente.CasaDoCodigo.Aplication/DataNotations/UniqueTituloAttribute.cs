namespace Com.DevEficiente.CasaDoCodigo.Aplication.DataNotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueTituloAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string titulo = value.ToString();
                var repository = (ILivroRepository)validationContext.GetService(typeof(ILivroRepository));

                if (repository == null)
                {
                    throw new InvalidOperationException("ILivroRepository não foi injetado corretamente.");
                }

                // Verifica a unicidade do título no banco de dados
                bool isTituloUnique = repository.IsTituloUnique(titulo).Result;

                if (!isTituloUnique)
                {
                    return new ValidationResult("O título já existe no banco de dados.");
                }
            }

            return ValidationResult.Success;
        }
    }
}