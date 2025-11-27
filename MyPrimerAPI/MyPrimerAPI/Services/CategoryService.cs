using AutoMapper;
using MyPrimerAPI.DAL.Models;
using MyPrimerAPI.DAL.Models.Dtos;
using MyPrimerAPI.Repository.IRepository;
using MyPrimerAPI.Services.IServices;

namespace MyPrimerAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); // solo estoy llamando al repositorio

            return _mapper.Map<ICollection<CategoryDto>>(categories); // mapeo los datos obtenidos a CategoryDto
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category= await _categoryRepository.GetCategoryAsync(id); // solo estoy llamando al repositorio

            return _mapper.Map<CategoryDto>(category); // mapeo los datos obtenidos a CategoryDto

        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
