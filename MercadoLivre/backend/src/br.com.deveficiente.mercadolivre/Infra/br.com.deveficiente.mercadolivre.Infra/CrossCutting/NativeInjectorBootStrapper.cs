using br.com.deveficiente.mercadolivre.Application.CommandHandler;
using br.com.deveficiente.mercadolivre.Application.Commands;
using br.com.deveficiente.mercadolivre.Application.Response;
using br.com.deveficiente.mercadolivre.Domain.Builders.LoginUser;
using br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository;
using br.com.deveficiente.mercadolivre.Domain.Interfaces.UnitOfWork;
using br.com.deveficiente.mercadolivre.Domain.NotificationObjects;
using br.com.deveficiente.mercadolivre.Domain.ResultObjects;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Context;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.Repositorys;
using br.com.deveficiente.mercadolivre.Infra.Data.SqlServer.UnitOfWork;
using MediatR;
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

        public static void mercadolivreRegisterSqslDBServices(IServiceCollection services, IConfiguration configuracao)
        {
            services.AddDbContext<ApplicationContext>(p => p.UseSqlServer(configuracao.GetConnectionString("ConnectionStrings")));
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
