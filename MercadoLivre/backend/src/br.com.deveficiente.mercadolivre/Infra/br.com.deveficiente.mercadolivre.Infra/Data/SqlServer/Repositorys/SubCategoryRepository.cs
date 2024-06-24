namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Repositorys
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}