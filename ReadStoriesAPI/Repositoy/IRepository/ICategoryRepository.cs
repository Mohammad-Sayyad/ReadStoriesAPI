using ReadStoriesAPI.Models;
using ReadStoriesAPI.Models.Dto;
using System.Linq.Expressions;

namespace ReadStoriesAPI.Repositoy.IRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetCategoriesProducts();
        Task<Category> GetById(int id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
    }
}
