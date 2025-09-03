namespace store_API.DTOs.Responses
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
