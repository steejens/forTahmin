
using Application.Configurations;
using Application.Configurations.Commands;

namespace Application.cqrs.Commands.CreateProduct

{
    public class CreateProductCommand : CommandBase<CreateProductResponse>
    {
        public CreateProductCommand(CreateProductRequest request)
        {
            Request = request;
        }

        public CreateProductRequest Request { get; set; }
    }
}
