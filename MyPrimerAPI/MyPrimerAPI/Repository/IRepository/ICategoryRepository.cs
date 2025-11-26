using MyPrimerAPI.DAL.Models;

namespace MyPrimerAPI.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync();// me retorna todas las categorias
        Task<Category> GetCategoryAsync(int Id);// me retorna una categoria por id
        Task<bool> CategoryExistsByIdAsync(int Id);// me dice si existe una categoria por id
        Task<bool> CategoryExistsByNameAsync(string name);// me dice si existe una categoria por nombre
        Task<bool> CreateCategoryAsync(Category category);// me crea una categoria
        Task<bool> UpdateCategoryAsync(Category category);// me actualiza una categoria
        Task<bool> DeleteCategoryAsync(int Id);// me elimina una categoria por id
    }

}
