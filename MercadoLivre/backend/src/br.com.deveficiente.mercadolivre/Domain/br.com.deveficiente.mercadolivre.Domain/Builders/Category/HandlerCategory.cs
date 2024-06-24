namespace br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser
{
    public class HandlerCategory
    {
        private IBuilderCategory BuilderCategory;

        public HandlerCategory(IBuilderCategory buildercategory)
        {
            BuilderCategory = buildercategory;
        }

        public SubCategory builderCategory(int IdCategory, string Name)
        {
            return BuilderCategory.BuilderSubCategory(IdCategory, Name);
        }
    }
}