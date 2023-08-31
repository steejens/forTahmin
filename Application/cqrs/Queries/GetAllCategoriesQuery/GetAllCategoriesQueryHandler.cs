using Application.Configurations.Queries;
using Application.Entities;
using Application.Repository.CategoryRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;



namespace Application.cqrs.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;



        public GetAllCategoriesQueryHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
        {


            var categoriesWithProducts = await _repository.GetAll("Products").ToListAsync();
            if (categoriesWithProducts == null)
            {
                throw new Exception();
            }
            var result = _mapper.Map<List<Category>, List<CategoryResponse>>(categoriesWithProducts);

            return new GetAllCategoriesResponse() { Categories = result};
        }
    
    }
}
