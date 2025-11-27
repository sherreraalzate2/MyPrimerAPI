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

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
          bool existe = await _categoryRepository.CategoryExistsByNameAsync(name);
            return existe;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto CategoryCreateDto)
        {
            //Validar si la categoria ya existe
            var categoryExists =await CategoryExistsByNameAsync(CategoryCreateDto.Name);
            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{CategoryCreateDto.Name}'");
            }
            //Mapear el CategoryCreateDto a Category para pasarlo al repositorio 
            var category = _mapper.Map<Category>(CategoryCreateDto);

            //Llamar al repositorio para crear la categoria

           var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Error al crear la categoria");
            }
            //Mapear el resultado a CategoryDto para devolverlo
            return _mapper.Map<CategoryDto>(category);
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

        public Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
