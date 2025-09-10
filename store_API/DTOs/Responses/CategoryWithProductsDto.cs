namespace store_API.DTOs.Responses
{
    public class CategoryWithProductsDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductReadDto> Products { get; set; }
    }
}
