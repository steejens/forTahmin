using Application.Configurations.Commands;
using Application.cqrs.Commands.CreateCategory;
using Application.Entities;
using Application.Repository;
using Application.Repository.CategoryRepository;
using MediatR;



namespace Application.cqrs.CreateCategory
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var title = command.Request.Title;

            var itemExists = await _repository.IsExistAsync(x => x.Title == title && x.Title != null);
            if (itemExists)
            {
                throw new Exception();
            }
            var catId = Guid.NewGuid();

            await _repository.AddAsync(new Category()
            {
                Id = Guid.NewGuid(),
                Status = Enums.StatusEnum.Active,
                Title = title,
                DateCreated = DateTime.Now
            });


            await _unitOfWork.CompleteAsync();
 
            return new CreateCategoryResponse();

        }
    }
}
