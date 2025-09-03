using System.ComponentModel.DataAnnotations;

namespace store_API.DTOs.Requests
{
    public class CategoryCreateDto
    {


        [Required]
        [MinLength(3,ErrorMessage = "Category name cannot be les than 3 characters.")]
        public string Name { get; set; }
    }
}
