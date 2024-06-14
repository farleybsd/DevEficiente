using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace br.com.deveficiente.mercadolivre.Application.CommandHandler
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Result<UserCreateResponse>>
    {
        private readonly IUnitOfWork Uow;
        private readonly NotificationContext NotificationContext;

        public UserCreateCommandHandler(IUnitOfWork uow,
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
            catch (DbUpdateException ex)
            {
                var sqlException = ex.InnerException as SqlException;

                if (sqlException != null && sqlException.Number == 2601) // Código de erro do SQL Server para violação de índice único
                {
                    NotificationContext.AddNotification("Erro ao Salvar um Login", "Email já cadastrado");
                    return new Result<UserCreateResponse>()
                    {
                        Succeeded = false,
                        Errors = new List<string>() { "Erro ao Salvar um Login" }
                    };

                    Uow.Rollback();
                    throw;
                }

                NotificationContext.AddNotification("Ocorreu um erro ao salvar as mudanças", $"{ex.Message}");
                return new Result<UserCreateResponse>()
                {
                    Succeeded = false,
                    Errors = new List<string>() { "Ocorreu um erro ao salvar as mudanças " }
                };

                Uow.Rollback();
                throw;

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