using Application.cqrs.Queries.GetAllCategoriesQuery;
using Application.Entities;
using AutoMapper;


namespace Application.cqrs.Mapping
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
