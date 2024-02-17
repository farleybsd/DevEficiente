namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<Categoria> BuscarCategoriaPorNome(string nome)
        {
            var filter = Builders<Categoria>.Filter.Eq(p => p.Nome, nome);

            var data = await DbSet.FindAsync(filter);

            return data.SingleOrDefault();
        }
    }
}