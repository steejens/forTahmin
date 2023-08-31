using BasicApp.Controllers;
using Application.cqrs.Commands.CreateCategory;
using Application.cqrs.Commands.CreateProduct;
using Microsoft.AspNetCore.Mvc;
using Application.cqrs.Queries.GetAllCategoriesQuery;

namespace Application.Controllers.Project
{
    public class ProjectController : BaseController
    {

        [Produces("application/json")]
        [HttpGet]
        public async Task<GetAllCategoriesResponse> GetAllAsync([FromQuery] GetAllCategoriesRequest request)
        {
            var result = await Mediator.Send(new GetAllCategoriesQuery(request));
            return result;
        }


        [Produces("application/json")]
        [HttpPost("category")]
        public async Task<CreateCategoryResponse> CreateCategoryAsync([FromBody] CreateCategoryRequest request)
        {
            var result = await Mediator.Send(new CreateCategoryCommand(request));
            return result;
        }

        [Produces("application/json")]
        [HttpPost("product")]
        public async Task<CreateProductResponse> CreateProductAsync([FromBody] CreateProductRequest request)
        {
            var result = await Mediator.Send(new CreateProductCommand(request));
            return result;
        }
    }
}
