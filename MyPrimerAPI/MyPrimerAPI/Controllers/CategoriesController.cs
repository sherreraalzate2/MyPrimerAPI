using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPrimerAPI.DAL.Models.Dtos;
using MyPrimerAPI.Services;
using MyPrimerAPI.Services.IServices;

namespace MyPrimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;
        public CategoriesController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await _categoryServices.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}
