
namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;

        protected IMongoCollection<TEntity> DbSet;

        public BaseRepository(IMongoContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public virtual async Task<TEntity> GetById(string id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id)));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public async virtual Task Update(string id, TEntity obj)
        {
            await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id)), obj);
        }

        public async virtual Task Remove(string id)
        {
            await DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id)));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByConnectorAndTable(string connectorName, string tableName)
        {
            throw new NotImplementedException();
        }

        public async Task Add(TEntity obj)
        {
            await DbSet.InsertOneAsync(obj);
        }
    }
}
