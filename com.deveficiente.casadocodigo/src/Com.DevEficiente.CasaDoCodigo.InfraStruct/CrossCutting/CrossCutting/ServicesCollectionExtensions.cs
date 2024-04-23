using Com.DevEficiente.CasaDoCodigo.Aplication.Result;
using Com.DevEficiente.CasaDoCodigo.Domain.Builders;
using Com.DevEficiente.CasaDoCodigo.Domain.Builders.Cupons;

namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.CrossCutting.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void CasaDoCodigoRegisterMongoDBServices(IServiceCollection services)
        {
            services.AddSingleton<IMongoContext, MongoContext>();
            services.AddSingleton<IAutorRepository, AutorRepository>();
            services.AddSingleton<ICategoriaRepository, CategoriaRepository>();
            services.AddSingleton<ILivroRepository, LivroRepository>();
            services.AddSingleton<IPaisRepository, PaisRepository>();
            services.AddSingleton<IEstadoRepository, EstadoRepository>();
            services.AddSingleton<ICompraRepository, CompraRepository>();
            services.AddSingleton<ICupomRepository, CupomRepository>();
        }

        public static void CasaDoCodigoRegisterMediatR(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AutorSaveCommand, AutorResponse>, AutorSaveCommandHandler>();
            services.AddScoped<IRequestHandler<AutorByIdQueryCommand, AutorByIdQueryResult>, AutorByIdQueryHandler>();
            services.AddScoped<IRequestHandler<AutorDeleteCommand, string>, AutorDeleteCommandHandler>();
            services.AddScoped<IRequestHandler<BuscarTodosAutoresCommand, IEnumerable<AutorResponse>>, BuscarTodosAutoresCommandHandler>();
            services.AddScoped<IRequestHandler<AutorEditarCommand, AutorResponse>, AutorEditarCommandHandler>();
            services.AddScoped<IRequestHandler<CategoriaSaveCommand, CategoriaResponse>, CategoriaSaveCommandHandler>();
            services.AddScoped<IRequestHandler<LivroSaveCommand, LivroResponse>, LivroSaveCommandHandler>();
            services.AddScoped<IRequestHandler<LivroByIdQueryCommand, LivroByIdQueryResult>, LivroByIdQueryHandler>();
            services.AddScoped<IRequestHandler<DetalhesDoLivroSiteCommand, DetalhesDoLivroSiteResponse>, DetalhesDoLivroSiteQueryHandler>();
            services.AddScoped<IRequestHandler<PaisSaveCommand, PaisResponse>, PaisSaveCommandHandler>();
            services.AddScoped<IRequestHandler<EstadoSaveCommand, EstadoResponse>, EstadoSaveCommandHandler>();
            services.AddScoped<IRequestHandler<CompraSaveCommand, CompraResult>, CompraSaveCommandHandler>();
            services.AddScoped<IRequestHandler<CupomSaveCommand, CupomResult>, CupomSaveCommandHandler>();
        }

        public static void CasaDoCodigoRegisterBuilder(IServiceCollection services)
        {
            services.AddScoped<IConstrutorCompraBuilder, ConstrutorCompra>();
            services.AddScoped<IConstrutorCupomBuilder, ConstrutorCupom>();
        }
    }
}