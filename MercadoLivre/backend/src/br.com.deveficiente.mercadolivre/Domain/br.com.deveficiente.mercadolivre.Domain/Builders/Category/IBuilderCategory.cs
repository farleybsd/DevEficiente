namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public interface IBuilderCategory
    {
        SubCategory BuilderSubCategory(int IdCategory, string Name);
    }
}