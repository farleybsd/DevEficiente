using br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser;
using br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Context;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Repositorys;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace br.com.deveficiente.mercadolivre.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void mercadolivreRegisterBuilder(IServiceCollection services)
        {
            services.AddScoped<IBuilderLogin, BuilderLogin>();
        }

        public static void mercadolivreRegisterMongoDBServices(IServiceCollection services, IConfiguration configuracao)
        {
            services.AddDbContext<ApplicationContext>(p => p.UseSqlServer(configuracao.GetConnectionString("SqlServerSettings")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoginRepository, LoginRepository>();

        }
    }
}
