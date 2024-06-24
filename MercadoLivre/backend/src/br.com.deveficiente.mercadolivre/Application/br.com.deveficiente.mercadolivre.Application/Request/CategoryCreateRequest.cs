namespace br.com.deveficiente.mercadolivre.Application.Request
{
    public class CategoryCreateRequest
    {
        [Required(ErrorMessage = "IdCategory é obrigatório.")]
        public int IdCategory { get; set; }

        [Required(ErrorMessage = "CategoryName é obrigatória")]
        public string CategoryName { get; set; }

        public CategoryCreateCommand RequestToCommand(CategoryCreateRequest categoryCreateRequest)
        {
            return new CategoryCreateCommand(categoryCreateRequest.IdCategory, categoryCreateRequest.CategoryName);
        }
    }
}