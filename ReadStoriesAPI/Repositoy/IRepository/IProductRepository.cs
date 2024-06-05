using ReadStoriesAPI.Models;
using System.Linq.Expressions;

namespace ReadStoriesAPI.Repositoy.IRepository
{

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);
    }
}
