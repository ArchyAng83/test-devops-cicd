using Microsoft.EntityFrameworkCore;
using TestDevOpsApp.Application.Interfaces;
using TestDevOpsApp.Domain.Entities;
using TestDevOpsApp.Infrastructure.Data;

namespace TestDevOpsApp.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<Guid> AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await context.Products.ToListAsync();
    }
}
