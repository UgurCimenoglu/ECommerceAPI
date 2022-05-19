using ECommerceAPI.Application.Repositories.CustomerRepository;
using ECommerceAPI.Application.Repositories.OrderRepository;
using ECommerceAPI.Application.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;


        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        //[HttpGet("a")]
        //public async Task Save()
        //{
        //    await _productWriteRepository.AddRangeAsync(new()
        //    {
        //        new() { Id = Guid.NewGuid(), Name = "Product 1", CreateDate = DateTime.UtcNow, Price = 100, Stock = 49 },
        //        new() { Id = Guid.NewGuid(), Name = "Product 2", CreateDate = DateTime.UtcNow, Price = 200, Stock = 21 },
        //        new() { Id = Guid.NewGuid(), Name = "Product 3", CreateDate = DateTime.UtcNow, Price = 40, Stock = 13 },
        //    });
        //    await _productWriteRepository.SaveAsync();

        //}

        [HttpGet]
        public async Task Get()
        {
            var order = await _orderReadRepository.GetByIdAsync("070d1bde-b6a6-4553-a680-ec250bc4366d");
            order.Address = "Çankırı";
            await _orderWriteRepository.SaveAsync();
        }
    }
}
