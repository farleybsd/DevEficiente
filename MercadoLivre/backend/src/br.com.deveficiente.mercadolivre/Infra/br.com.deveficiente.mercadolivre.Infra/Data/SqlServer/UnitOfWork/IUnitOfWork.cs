using br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository;

namespace br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        ILoginRepository LoginRepository { get; }
    }
}
