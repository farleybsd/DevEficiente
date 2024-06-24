namespace br.com.deveficiente.mercadolivre.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void mercadolivreRegisterBuilder(IServiceCollection services)
        {
            services.AddScoped<IBuilderCategory, BuilderCategory>();
        }

        public static void mercadolivreRegisterSqslDBServices(IServiceCollection services, string conexao)
        {
            services.AddDbContext<ApplicationContext>(p => p.UseSqlServer(conexao));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void CasaDoCodigoRegisterMediatR(IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
            services.AddScoped<IRequestHandler<UserCreateCommand, Result<UserCreateResponse>>, UserCreateCommandHandler>();
            services.AddScoped<IRequestHandler<CategoryCreateCommand, Result<CategoryCreateResponse>>, CategoryCreateCommandHandler>();
        }
    }
}