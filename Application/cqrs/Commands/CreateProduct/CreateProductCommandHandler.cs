using Application.Configurations.Commands;
using Application.cqrs.Commands.CreateProduct;
using Application.Entities;
using Application.Repository;
using Application.Repository.ProductRepository;
using MediatR;



namespace Application.cqrs.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var title = command.Request.Title;

            var itemExists = await _repository.IsExistAsync(x => x.Title == title && x.Title != null);
            if (itemExists)
            {
                throw new Exception();
            }
            var catId = Guid.NewGuid();

            await _repository.AddAsync(new Product()
            {
                Id = Guid.NewGuid(),
                Status = Enums.StatusEnum.Active,
                Title = title,
                CatId = command.Request.CatId,
                DateCreated = DateTime.Now
            });


            await _unitOfWork.CompleteAsync();
 
            return new CreateProductResponse();

        }
    }
}
