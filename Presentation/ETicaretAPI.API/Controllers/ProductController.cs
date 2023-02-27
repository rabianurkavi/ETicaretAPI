using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            // {
            //     new() {Id=Guid.NewGuid(),Name="Product 4", Price=200, CreatedDate=DateTime.Now,Stock=20},
            //     new() {Id=Guid.NewGuid(),Name="Product 5", Price=500, CreatedDate=DateTime.Now,Stock=40},
            //     new() {Id=Guid.NewGuid(),Name="Product 6", Price=750, CreatedDate=DateTime.Now,Stock=50},
            // });
            Product product = await _productReadRepository.GetByIdAsync("30634E9C-5BB8-480D-90CC-6301EDE5B2E4",false);
            product.Name = "Nur";
            await _productWriteRepository.SaveAsync();
        }
    }
}
