namespace ReadStoriesAPI.Models.Dto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
