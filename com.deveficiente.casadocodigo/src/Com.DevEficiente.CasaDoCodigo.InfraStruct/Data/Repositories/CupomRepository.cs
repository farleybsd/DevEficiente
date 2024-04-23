namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories
{
    public class CupomRepository : BaseRepository<Cupom>, ICupomRepository
    {
        public CupomRepository(IMongoContext context) : base(context)
        {
            CriarIndiceUnico("_Codigo");
        }
    }
}