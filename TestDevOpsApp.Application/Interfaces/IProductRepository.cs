using TestDevOpsApp.Domain.Entities;

namespace TestDevOpsApp.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Guid> AddAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
