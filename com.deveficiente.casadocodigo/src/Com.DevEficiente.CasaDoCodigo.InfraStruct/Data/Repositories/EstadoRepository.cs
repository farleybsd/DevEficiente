namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(IMongoContext context) : base(context)
        {
            CriarIndiceUnico("NomeEstado");
        }
    }
}