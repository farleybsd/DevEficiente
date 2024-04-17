namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {
        public PaisRepository(IMongoContext context) : base(context)
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
            var field = new StringFieldDefinition<Pais>("Nome");
            var indexDefinition = new IndexKeysDefinitionBuilder<Pais>().Ascending(field);

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