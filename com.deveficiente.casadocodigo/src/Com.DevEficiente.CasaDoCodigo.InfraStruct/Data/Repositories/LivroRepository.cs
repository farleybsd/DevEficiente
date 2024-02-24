

namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        public LivroRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<bool> IsTituloUnique(string titulo)
        {
            var filter = Builders<Livro>.Filter.Eq(p => p.Titulo.Titulo, titulo);

            var count = DbSet.CountDocuments(filter);

            return count == 0;
        }
    }
}
