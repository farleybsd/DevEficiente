namespace br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithSubCategoriesAsync(int id);
    }
}