using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoriesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]

        public ActionResult<IEnumerable<CategoryReadDto>> GetAll()
        {

            var categoriesDTO = _appDbContext.Categories.AsNoTracking().Select(category => new CategoryReadDto
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();

            return Ok(categoriesDTO);
        }

        [HttpPost]

        public ActionResult CreateCategory(CategoryCreateDto request)
        {
            var category = new Category
            { 

             Name = request.Name

                };

            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();


            return Ok();
        }


    }
}
