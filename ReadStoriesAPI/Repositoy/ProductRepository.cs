using Microsoft.EntityFrameworkCore;
using ReadStoriesAPI.Data;
using System.Linq.Expressions;
using ReadStoriesAPI.Repositoy.IRepository;
using ReadStoriesAPI.Models;

namespace ReadStoriesAPI.Repositoy
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetAll() => 
            await _context.Products                                           
            .AsNoTracking()
                                                                  .DefaultIfEmpty()
                                                                  .Include(c => c.Category)
                                                                  .ToListAsync();

        public async Task<Product> GetById(int id) => await _context.Products
                                                            .AsNoTracking()
                                                            .DefaultIfEmpty()
                                                            
                                                            .SingleOrDefaultAsync(p => p.ProductId == id);

        public async Task<Product> Create(Product product)
        {
            await _context.AddAsync(product);
            await SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await GetById(id);
            _context.Products.Remove(product);
            await SaveChangesAsync();

            return product;
        }

        private async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
