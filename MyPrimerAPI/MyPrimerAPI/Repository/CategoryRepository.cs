using Microsoft.EntityFrameworkCore;
using MyPrimerAPI.DAL;
using MyPrimerAPI.DAL.Models;
using MyPrimerAPI.Repository.IRepository;

namespace MyPrimerAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CategoryExistsByIdAsync(int Id)
        {
         return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == Id); //lambda expression
            //Select case when exists (Select * from Categories where Id = Id) then 1 else 0 end
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _context.Categories
                   .AsNoTracking()
                   .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;
            await _context.Categories.AddAsync(category);
            return await SaveAsync();
            // sql INSERT savechangesAsync
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
         var category = await GetCategoryAsync(id);
            if (category == null)
            {
                return false; // la categoria no existe
            }
            _context.Categories.Remove(category);
            return await SaveAsync();

            // sql Delete From Categories where Id = id
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                   .AsNoTracking()
                   .OrderBy(c => c.Name)
                   .ToListAsync(); 

        }
         
        public async Task<Category> GetCategoryAsync(int id) //async y el await
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id); //lambda expression
            //Select * from Categories where Id = Id

        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;
            _context.Categories.Update(category);
            return await SaveAsync();
        }
        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
