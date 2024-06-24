namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public class BuilderCategory : IBuilderCategory
    {
        private SubCategory Category = new SubCategory();

        public SubCategory BuilderSubCategory(int IdCategory, string Name)
        {
            Category.setCategoriaId(IdCategory);
            Category.setName(Name);
            return Category;
        }
    }
}