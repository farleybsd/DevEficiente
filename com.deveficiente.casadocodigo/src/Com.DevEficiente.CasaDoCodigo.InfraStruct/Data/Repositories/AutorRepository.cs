

namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(IMongoContext context) : base(context)
        {
            
        }
    }
}
