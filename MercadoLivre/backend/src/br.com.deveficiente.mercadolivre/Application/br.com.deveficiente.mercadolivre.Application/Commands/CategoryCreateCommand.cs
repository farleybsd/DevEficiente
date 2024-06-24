namespace br.com.deveficiente.mercadolivre.Application.Commands
{
    public class CategoryCreateCommand : IRequest<Result<CategoryCreateResponse>>
    {
        public int IdCategory { get; private set; }
        public string CategoryName { get; private set; }

        public CategoryCreateCommand(int idCategory, string categoryName)
        {
            IdCategory = idCategory;
            CategoryName = categoryName;
        }

        public SubCategory CommandToEntity(CategoryCreateCommand userCreateCommand)
        {
            var builderCategory = new BuilderCategory();
            var handlerCategory = new HandlerCategory(builderCategory);
            var encryptionKey = "ChaveSecreta123";

            var category = handlerCategory.builderCategory(userCreateCommand.IdCategory, userCreateCommand.CategoryName);
            return category;
        }
    }
}