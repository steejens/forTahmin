using Application.Repository;
using Application.Entities;


namespace Application.Repository.CategoryRepository
{
    public interface ICategoryRepository : IRepository<Category>, IRepositoryIdentifier
    {
    }
}
