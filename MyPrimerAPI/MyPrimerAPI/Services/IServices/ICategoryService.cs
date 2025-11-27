using MyPrimerAPI.DAL.Models;
using MyPrimerAPI.DAL.Models.Dtos;

namespace MyPrimerAPI.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<bool> CategoryExistsByIdAsync(int id);
        Task<bool> CategoryExistsByNameAsync(string name);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto); 
        Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto); 
        Task<bool> DeleteCategoryAsync(int id); 
    }
} 
