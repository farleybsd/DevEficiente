using br.com.deveficiente.mercadolivre.Domain.Entity;
using br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Base;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Context;

namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Repositorys
{
    public class LoginRepository : GenericRepository<Login>, ILoginRepository
    {
        public LoginRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
