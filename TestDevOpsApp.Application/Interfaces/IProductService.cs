using TestDevOpsApp.Application.DTOs;

namespace TestDevOpsApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateAsync(CreateProductDto dto);
        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}
