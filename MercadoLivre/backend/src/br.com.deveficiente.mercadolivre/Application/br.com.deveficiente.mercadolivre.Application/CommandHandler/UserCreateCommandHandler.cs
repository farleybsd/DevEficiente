using br.com.deveficiente.mercadolivre.Application.Commands;
using br.com.deveficiente.mercadolivre.Application.Response;
using br.com.deveficiente.mercadolivre.Domain.Interfaces.UnitOfWork;
using br.com.deveficiente.mercadolivre.Domain.NotificationObjects;
using br.com.deveficiente.mercadolivre.Domain.ResultObjects;
using MediatR;

namespace br.com.deveficiente.mercadolivre.Application.CommandHandler
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Result<UserCreateResponse>>
    {
        private readonly IUnitOfWork Uow;
        private readonly NotificationContext NotificationContext;
        public UserCreateCommandHandler( IUnitOfWork uow,
                                        NotificationContext notificationContext)
        {
            Uow = uow;
            NotificationContext = notificationContext;
        }
        public async Task<Result<UserCreateResponse>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Uow.BeginTransaction();
                var Login = request.CommandToEntity(request);
                Uow.LoginRepository.Add(Login);
                Uow.Commit();

                return new Result<UserCreateResponse>()
                {
                    Succeeded = true,
                    Data = new UserCreateResponse()
                    {
                        Email = request.Email,
                        Password = request.Password
                    }
                };
            }
            catch (Exception e)
            {
                NotificationContext.AddNotification("Erro ao Salvar um Login", "Erro Inesperado");
                return new Result<UserCreateResponse>()
                {
                    Succeeded = false,
                    Errors = new List<string>() { "Erro ao Salvar um Login" }
                };

                Uow.Rollback();
                throw;
            }
            

        }
    }
}
