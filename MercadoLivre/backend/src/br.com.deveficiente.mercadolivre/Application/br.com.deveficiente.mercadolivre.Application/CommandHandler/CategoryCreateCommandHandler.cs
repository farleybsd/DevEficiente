using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace br.com.deveficiente.mercadolivre.Application.CommandHandler
{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Result<CategoryCreateResponse>>
    {
        private readonly IUnitOfWork Uow;
        private readonly NotificationContext NotificationContext;

        public CategoryCreateCommandHandler(IUnitOfWork uow,
                                        NotificationContext notificationContext)
        {
            Uow = uow;
            NotificationContext = notificationContext;
        }

        public async Task<Result<CategoryCreateResponse>> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            Uow.BeginTransaction();
            var categoryMotherName = await Uow.CategoryRepository.GetByIdAsync(request.IdCategory);
            var subcategory = request.CommandToEntity(request);
            Uow.SubCategoryRepository.Add(subcategory);
            Uow.Commit();
            
            return new Result<CategoryCreateResponse>()
            {
                Succeeded = true,
                Data = new CategoryCreateResponse()
                {
                    IdCategorymother = request.IdCategory,
                    CategoryName = request.CategoryName,
                    CategoryMother = categoryMotherName.Name,
                }
            };
        }
    }
}