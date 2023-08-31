using Application.Repository;
using Application.Entities;


namespace Application.Repository.ProductRepository
{
    public interface IProductRepository : IRepository<Product>, IRepositoryIdentifier
    {
    }
}
