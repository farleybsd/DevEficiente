using Com.DevEficiente.CasaDoCodigo.Domain.Entidades;
using Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio;
using Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Interface;
using Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories.Base;

namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(IMongoContext context) : base(context)
        {
            
        }
    }
}
