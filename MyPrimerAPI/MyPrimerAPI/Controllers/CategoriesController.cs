using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        [HttpGet("{id:int}", Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategoryAsync(int id)
        {
            var categoryDto = await _categoryServices.GetCategoryAsync(id);
            return Ok(categoryDto);
        }

        [HttpPost (Name = "CreatedCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CategoryDto>> CreatedCategoryAsync([FromBody]CategoryCreateDto categoryCreateDto) 
        {
            if (!ModelState.IsValid) 
                {
                return BadRequest(ModelState);
            }

            try
            {
                var createdCategory = await _categoryServices.CreateCategoryAsync(categoryCreateDto);

                // vamos a retornar un 201 Created con la ruta para obtener la categoria creada

                return CreatedAtRoute("GetCategoryAsync", new { id = createdCategory.Id }, createdCategory);

            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe"))
            {
                return Conflict(new { ex.Message });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

    }
}
 