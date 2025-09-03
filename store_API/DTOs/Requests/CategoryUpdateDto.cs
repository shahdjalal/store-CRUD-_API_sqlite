using System.ComponentModel.DataAnnotations;

namespace store_API.DTOs.Requests
{
    public class CategoryUpdateDto
    {


        [MinLength(3,ErrorMessage = "Category name cannot be less than 3 characters.")]
        public string? Name { get; set; }
    }
}
