﻿using Microsoft.EntityFrameworkCore;
using ReadStoriesAPI.Data;
using ReadStoriesAPI.Models;
using ReadStoriesAPI.Models.Dto;
using ReadStoriesAPI.Repositoy.IRepository;
using System.Linq.Expressions;

namespace ReadStoriesAPI.Repositoy
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Category>> GetAll() => await _context.Categories
                                                                   .AsNoTracking()
                                                                   .DefaultIfEmpty().Include(x=> x.Products)
                                                                   .ToListAsync();

        public async Task<IEnumerable<Category>> GetCategoriesProducts() => await _context.Categories
                                                                                     .AsNoTracking()
                                                                                     .DefaultIfEmpty()
                                                                                     .Include(p => p.Products)
                                                                                     .ToListAsync();

        public async Task<Category> GetById(int id) => await _context.Categories
                                                             .AsNoTracking()
                                                             .DefaultIfEmpty().Include(x=> x.Products)
                                                             .SingleOrDefaultAsync(p => p.CategoryId == id);

        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await SaveChangesAsync();

            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await SaveChangesAsync();

            return category;
        }
        public async Task<Category> Delete(int id)
        {
            var category = await GetById(id);
            _context.Categories.Remove(category);
            await SaveChangesAsync();

            return category;
        }

        private async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
