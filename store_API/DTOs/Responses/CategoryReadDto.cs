using System.ComponentModel.DataAnnotations;

namespace store_API.DTOs.Responses
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
