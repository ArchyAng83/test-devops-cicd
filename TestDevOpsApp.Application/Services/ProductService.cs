using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDevOpsApp.Application.DTOs;
using TestDevOpsApp.Application.Interfaces;
using TestDevOpsApp.Domain.Entities;

namespace TestDevOpsApp.Application.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        public async Task<Guid> CreateAsync(CreateProductDto dto)
        {
            var product = new Product { Name = dto.Name, Price = dto.Price };
            return await repository.AddAsync(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await repository.GetAllAsync();
            return products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price));
        }
    }
}
