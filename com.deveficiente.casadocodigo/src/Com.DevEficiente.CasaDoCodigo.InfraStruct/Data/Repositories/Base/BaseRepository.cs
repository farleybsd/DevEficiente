﻿namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories.Base
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

        public virtual async Task Update(string id, TEntity obj)
        {
            await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id)), obj);
        }

        public virtual async Task Remove(string id)
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

        // Método Template que coordena a criação do índice
        public void CriarIndiceUnico(string campo)
        {
            var options = new CreateIndexOptions
            {
                Unique = true,
                Collation = new Collation("pt", strength: CollationStrength.Primary, caseLevel: false)
            };

            var field = new StringFieldDefinition<TEntity>(campo);
            var indexDefinition = new IndexKeysDefinitionBuilder<TEntity>().Ascending(field);

            // Verifica se a coleção já possui índices
            var indexes = DbSet.Indexes.List().ToList();
            bool collectionHasIndexes = indexes.Any();

            // Cria o índice apenas se a coleção não tiver índices ainda
            if (!collectionHasIndexes)
            {
                DbSet.Indexes.CreateOne(indexDefinition, options);
            }
        }
    }
}