
using Application.Configurations.Queries;

namespace Application.cqrs.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQuery : IQuery<GetAllCategoriesResponse>
    {
        public GetAllCategoriesQuery(GetAllCategoriesRequest request)
        {
            Request = request;
        }

        public GetAllCategoriesRequest Request { get; set; }

    }
}
