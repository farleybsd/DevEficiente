using Com.DevEficiente.CasaDoCodigo.Aplication.CommandHandler;
using Com.DevEficiente.CasaDoCodigo.Aplication.Commands;
using Com.DevEficiente.CasaDoCodigo.Aplication.Response;
using Com.DevEficiente.CasaDoCodigo.Domain.Interface.Repositorio;
using Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Context;
using Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Interface;
using Com.DevEficiente.CasaDoCodigo.InfraStruct.Data.Repositories;
using MediatR;
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

        public static void CasaDoCodigoRegisterMediatR(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AutorSaveCommand, AutorResponse>, AutorSaveCommandHandler>();
        }
    }
}
