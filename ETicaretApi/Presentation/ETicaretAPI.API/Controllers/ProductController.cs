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
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductController
            (IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id= Guid.NewGuid(), Name= "Televizyon" , Price = 5678, Stock= 50, CreatedDate=DateTime.Now },
            //    new() { Id = Guid.NewGuid(), Name = "Telefon",  Price = 7520, Stock = 20, CreatedDate = DateTime.Now },

            //});
            //var count = await _productWriteRepository.SaveAsync();
            return Ok("Merhaba UI");
            

        }
    }
}
