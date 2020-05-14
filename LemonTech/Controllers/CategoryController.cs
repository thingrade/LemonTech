using System.Threading.Tasks;
using LemonTech.Repository.Category.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lemontech.DataLayer.Models;

namespace LtTask.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategoryList());
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await _categoryService.GetCategoryById(id));
        }

        [HttpPost("category/create")]
        public async Task<IActionResult> CreateCategory([FromBody] Category model)
        {
            return Ok(await _categoryService.CreateCategory(model));
        }

        [HttpPost("category/{id}/update")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category model)
        {
            if (model.Id == 0) model.Id = id;
            
            return Ok(await _categoryService.UpdateCategory(id, model));
        }

        [HttpDelete("category/{id}/delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await _categoryService.DeleteCategory(id));
        }
    }
}