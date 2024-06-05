using System.ComponentModel.DataAnnotations;

namespace ReadStoriesAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product>? Products { get; set; }
        //public ICollection<SubCategory>? SubCategories { get; set; }
    }
}
