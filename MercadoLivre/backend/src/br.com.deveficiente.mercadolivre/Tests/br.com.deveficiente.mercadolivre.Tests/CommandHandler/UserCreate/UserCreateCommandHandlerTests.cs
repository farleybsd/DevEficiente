using br.com.deveficiente.mercadolivre.Application.CommandHandler;
using br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository;
using br.com.deveficiente.mercadolivre.Domain.Interfaces.UnitOfWork;
using br.com.deveficiente.mercadolivre.Domain.NotificationObjects;
using Moq;

namespace br.com.deveficiente.mercadolivre.Tests.CommandHandler.UserCreate
{
    public class UserCreateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_SuccessfulCreation_ReturnsSucceededResult()
        {
            // Arrange
            var unitOffWorkMock = new Mock<IUnitOfWork>();
            var loginRepositoryMock = new Mock<ILoginRepository>();
            unitOffWorkMock.Setup( uow => uow.LoginRepository).Returns(loginRepositoryMock.Object);

            var notificationContext = new NotificationContext();
            var handler = new UserCreateCommandHandler(unitOffWorkMock.Object,notificationContext);

            var command = new  UserCreateCommandHandlerTestsDataBuilders()
                 .WithEmail("test@example.com")
                  .WithPassword("password123")
                  .Build();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Succeeded);
            Assert.NotNull(result.Data);
            Assert.Equal("test@example.com", result.Data.Email);
            Assert.Equal("password123", result.Data.Password);

        }

        [Fact]
        public async Task Handle_ExceptionThrown_ReturnsFailedResultAndAddsNotification()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var loginRepositoryMock = new Mock<ILoginRepository>();
            unitOfWorkMock.Setup(uow => uow.LoginRepository).Returns(loginRepositoryMock.Object);
            unitOfWorkMock.Setup(uow => uow.Commit()).Throws(new Exception("Database error"));

            var notificationContext = new NotificationContext();

            var handler = new UserCreateCommandHandler(unitOfWorkMock.Object, notificationContext);

            var command = new UserCreateCommandHandlerTestsDataBuilders()
                 .WithEmail("test@example.com")
                  .WithPassword("password123")
                  .Build();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Null(result.Data);
            Assert.Contains("Erro ao Salvar um Login", result.Errors);
            Assert.True(notificationContext.HasNotifications);
        }
    }
}

