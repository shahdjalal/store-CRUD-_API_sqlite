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

        public ActionResult<IEnumerable<ProductReadDto>> Get()
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

        public ActionResult Create(ProductCreateDto request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,

            };
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();

            return Ok();
        }

        [HttpGet("{id}")]

        public ActionResult<ProductReadDto> GetById(int id)
        {
            var product = _appDbContext.Products.Find(id);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            var productDto = new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return Ok(productDto);
        }







        [HttpPatch("{id}")]
        public ActionResult<IEnumerable<ProductReadDto>> Update(ProductUpdateDto request , int id)
        {
            var product = _appDbContext.Products.Find(id);

            if (request.Name is not null)
                product.Name = request.Name;

            if (request.Description is not null)
                product.Description = request.Description;

            if (request.Price.HasValue)
                product.Price = request.Price.Value;

            _appDbContext.SaveChanges();

            var readDTO = new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price=product.Price 
            };

            return Ok(readDTO);
            

        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {

            var product = _appDbContext.Products.Find(id);

            if (product is null)
                return NotFound();

            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
            return Ok(new { message = "deleted successfully" });
        }
    }
}
