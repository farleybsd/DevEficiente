namespace br.com.deveficiente.mercadolivre.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void mercadolivreRegisterBuilder(IServiceCollection services)
        {
            services.AddScoped<IBuilderLogin, BuilderLogin>();
        }

        public static void mercadolivreRegisterSqslDBServices(IServiceCollection services, string conexao)
        {
            services.AddDbContext<ApplicationContext>(p => p.UseSqlServer(conexao));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoginRepository, LoginRepository>();

        }

        public static void CasaDoCodigoRegisterMediatR(IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
            services.AddScoped<IRequestHandler<UserCreateCommand, Result<UserCreateResponse>>, UserCreateCommandHandler>();
        }
    }
}
