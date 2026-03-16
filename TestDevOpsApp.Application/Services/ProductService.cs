using StackExchange.Redis;
using System.Text.Json;
using TestDevOpsApp.Application.DTOs;
using TestDevOpsApp.Application.Interfaces;
using TestDevOpsApp.Domain.Entities;

namespace TestDevOpsApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IDatabase _cache;
        private const string CacheKey = "products_all";

        public ProductService(IProductRepository repository, IConnectionMultiplexer redis)
        {
            _repository = repository;
            _cache = redis.GetDatabase();
        }

        public async Task<Guid> CreateAsync(CreateProductDto dto)
        {
            var product = new Product { Name = dto.Name, Price = dto.Price };
            var id = await _repository.AddAsync(product);

            await _cache.KeyDeleteAsync(CacheKey);

            return id;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var cachedProducts = await _cache.StringGetAsync(CacheKey);
            if (cachedProducts.HasValue)
            {
                return JsonSerializer.Deserialize<IEnumerable<ProductDto>>(cachedProducts!)!;
            }

            var products = await _repository.GetAllAsync();
            var dtos = products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price));

            await _cache.StringSetAsync(CacheKey, JsonSerializer.Serialize(dtos), TimeSpan.FromMinutes(5));

            return dtos;
        }
    }
}
