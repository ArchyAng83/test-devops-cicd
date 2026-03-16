using Microsoft.AspNetCore.Mvc;
using TestDevOpsApp.Application.DTOs;
using TestDevOpsApp.Application.Interfaces;

namespace TestDevOpsApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto) =>
        Ok(await productService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await productService.GetAllAsync());
    }
}
