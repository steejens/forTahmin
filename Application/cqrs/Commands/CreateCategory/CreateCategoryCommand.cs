
using Application.Configurations.Commands;

namespace Application.cqrs.Commands.CreateCategory

{
    public class CreateCategoryCommand : CommandBase<CreateCategoryResponse>
    {
        public CreateCategoryCommand(CreateCategoryRequest request)
        {
            Request = request;
        }

        public CreateCategoryRequest Request { get; set; }
    }
}
