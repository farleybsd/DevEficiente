﻿using Com.DevEficiente.CasaDoCodigo.Aplication.Result;

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
        }
    }
}