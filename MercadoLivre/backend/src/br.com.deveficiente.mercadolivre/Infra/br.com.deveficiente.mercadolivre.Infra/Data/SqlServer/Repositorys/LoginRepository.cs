namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Repositorys
{
    public class LoginRepository : GenericRepository<Login>, ILoginRepository
    {
        public LoginRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
