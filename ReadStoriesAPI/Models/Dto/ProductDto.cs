using System.ComponentModel.DataAnnotations.Schema;

namespace ReadStoriesAPI.Models.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
