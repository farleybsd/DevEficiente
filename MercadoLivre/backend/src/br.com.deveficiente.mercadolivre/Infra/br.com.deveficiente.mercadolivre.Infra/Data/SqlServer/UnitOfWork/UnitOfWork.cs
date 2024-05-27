using br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Context;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Repositorys;

namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private ILoginRepository _loginRepository;
        public ILoginRepository LoginRepository
        {
            get => _loginRepository ?? (_loginRepository = new LoginRepository(_context));
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
