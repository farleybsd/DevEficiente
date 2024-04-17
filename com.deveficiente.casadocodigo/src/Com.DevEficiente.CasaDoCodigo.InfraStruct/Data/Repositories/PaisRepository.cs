namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {
        public PaisRepository(IMongoContext context) : base(context)
        {
        }
    }
}