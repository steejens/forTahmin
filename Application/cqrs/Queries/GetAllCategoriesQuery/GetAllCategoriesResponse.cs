using Application.Enums;

namespace Application.cqrs.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesResponse
    {
        public List<CategoryResponse> Categories { get; set; }

    }


    public class CategoryResponse
    {
        public string Title { get; set; }
        public StatusEnum Status { get; set; }
        public List<ProductResponse> Products { get; set; }

    }

    public class ProductResponse
    {
        public string Title { get; set; }
        public StatusEnum Status { get; set; }

    }
}
