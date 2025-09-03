using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_API.Data;
using store_API.DTOs.Requests;
using store_API.DTOs.Responses;
using store_API.Models;

namespace store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]

        public ActionResult<IEnumerable<ProductReadDto>> GetAll()
        {

            var productsDTO = _appDbContext.Products.AsNoTracking().Select(product => new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            }).ToList();

            return Ok(productsDTO);
        }

        [HttpPost]

        public ActionResult CreateProduct(ProductCreateDto request)
        {
            var product = new Product
            {
              Name=  request.Name,
                Description = request.Description,
                Price = request.Price ,
                CategoryId = request.CategoryId,

            };
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();

            return Ok();
        }
    }
}
