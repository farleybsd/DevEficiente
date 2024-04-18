namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(IMongoContext context) : base(context)
        {
            CriarIndiceUnico();
        }

        public void CriarIndiceUnico()
        {

            var options = new CreateIndexOptions
            {
                Unique = true,
                Collation = new Collation("pt", strength: CollationStrength.Primary, caseLevel: false)
            };
            var field = new StringFieldDefinition<Estado>("NomeEstado");
            var indexDefinition = new IndexKeysDefinitionBuilder<Estado>().Ascending(field);

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