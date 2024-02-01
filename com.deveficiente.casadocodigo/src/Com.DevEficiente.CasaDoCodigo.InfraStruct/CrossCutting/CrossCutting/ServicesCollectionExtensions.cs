
namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.CrossCutting.CrossCutting
{
    public  class NativeInjectorBootStrapper
    {
        public static void CasaDoCodigoRegisterMongoDBServices(IServiceCollection services)
        {
            services.AddSingleton<IMongoContext, MongoContext>();
            services.AddSingleton<IAutorRepository, AutorRepository>();
        }

        public static void CasaDoCodigoRegisterMediatR(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AutorSaveCommand, AutorResponse>, AutorSaveCommandHandler>();
        }
    }
}
