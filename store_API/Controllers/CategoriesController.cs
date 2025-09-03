using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_API.Data;
using store_API.DTOs.Requests;
using store_API.DTOs.Responses;
using store_API.Models;
using System.Threading.Tasks;

namespace store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoriesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]

        public ActionResult<IEnumerable<CategoryReadDto>> Get()
        {

            var categoriesDTO = _appDbContext.Categories.AsNoTracking().Select(category => new CategoryReadDto
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();

            return Ok(categoriesDTO);
        }


        [HttpGet("{id}")]

        public ActionResult<CategoryReadDto>  GetById(int id)
        {
            var category = _appDbContext.Categories.Find(id);

            if(category is null)
            {
                return NotFound(new { message = "category not found" });
            }

            var categoryDTO = new CategoryReadDto
            {
                Id=category.Id,
                Name=category.Name
            };

            return Ok(categoryDTO);

        }







        [HttpPost]

        public ActionResult Create(CategoryCreateDto request)
        {
            var category = new Category
            { 

             Name = request.Name

                };

            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();


            return Ok();
        }

        [HttpPatch("{id}")]
        public ActionResult<IEnumerable<CategoryReadDto>> Update(CategoryUpdateDto request , int id)
        {
            var category = _appDbContext.Categories.Find(id);

            category.Name = request.Name;

            _appDbContext.SaveChanges();

            var readDto = new CategoryReadDto
            {
                Id = category.Id,
                Name= category.Name
            };

            return Ok(readDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var category = _appDbContext.Categories.Find(id);

            if (category == null)
                return NotFound();

            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();


            return Ok(new {message="deleted successfully"});
        }


    }
}
