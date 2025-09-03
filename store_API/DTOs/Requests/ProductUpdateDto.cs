using System.ComponentModel.DataAnnotations;

namespace store_API.DTOs.Requests
{
    public class ProductUpdateDto
    {
       
        [MinLength(3, ErrorMessage = "Product name cannot be less than 3 characters.")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
       
    }
}
