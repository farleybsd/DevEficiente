namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class CompraRepository : BaseRepository<Compra>, ICompraRepository
    {
        public CompraRepository(IMongoContext context) : base(context)
        {
        }
    }
}