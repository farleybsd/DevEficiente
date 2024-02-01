using Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio;
using Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Context;
using Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Interface;
using Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Com.DevEficiente.CasaDoCodigo.InfraStruct.CrossCutting.CrossCutting
{
    public  class NativeInjectorBootStrapper
    {
        public static void CasaDoCodigoRegisterMongoDBServices(IServiceCollection services)
        {
            services.AddSingleton<IMongoContext, MongoContext>();
            services.AddSingleton<IAutorRepository, AutorRepository>();
        }
    }
}
