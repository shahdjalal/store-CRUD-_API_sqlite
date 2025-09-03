using System.ComponentModel.DataAnnotations;

namespace store_API.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
