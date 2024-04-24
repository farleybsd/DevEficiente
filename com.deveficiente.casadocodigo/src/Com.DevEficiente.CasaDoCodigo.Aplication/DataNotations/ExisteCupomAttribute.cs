namespace Com.DevEficiente.CasaDoCodigo.Aplication.DataNotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ExisteCupomAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string idCupom = value.ToString();
                var repository = (ICupomRepository)validationContext.GetService(typeof(ICupomRepository));

                if (repository == null)
                {
                    throw new InvalidOperationException("ICupomRepository não foi injetado corretamente.");
                }


                var cupom = repository.GetById(idCupom).Result;

                if (cupom == null)
                {
                    return new ValidationResult("O cupom nao existe no banco de dados.");
                }
            }

            return ValidationResult.Success;
        }
    }
}