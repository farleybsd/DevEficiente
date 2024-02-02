namespace Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);

        Task<TEntity> GetById(string id);

        Task<TEntity> GetByConnectorAndTable(string connectorName, string tableName);

        Task<IEnumerable<TEntity>> GetAll();

        Task Update(string id, TEntity obj);

        Task Remove(string id);
    }
}