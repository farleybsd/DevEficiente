using br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository;
using br.com.deveficiente.mercadolivre.Domain.Interfaces.UnitOfWork;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Context;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Repositorys;
using Microsoft.EntityFrameworkCore.Storage;

namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private IDbContextTransaction _transaction;

        private ILoginRepository _loginRepository;

        public ILoginRepository LoginRepository
        {
            get => _loginRepository ?? (_loginRepository = new LoginRepository(_context));
        }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            try
            {
                var changesSaved = _context.SaveChanges() > 0;
                _transaction?.Commit();
                return changesSaved;
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }
    }
}
