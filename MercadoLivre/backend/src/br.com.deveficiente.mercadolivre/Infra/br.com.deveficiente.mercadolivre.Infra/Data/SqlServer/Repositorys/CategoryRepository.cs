
using Microsoft.EntityFrameworkCore;

namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Repositorys
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesWithSubCategoriesAsync(int id)
        {
            return await _context.Category
                                .Include(c => c.subCategory)
                                .Where( x => x.Id == id)
                                .ToListAsync();
        }
    }
}