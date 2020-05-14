using System.Threading.Tasks;
using Lemontech.DataLayer.Models;
using LemonTech.Repository.Category.Interface;
using LemonTech.Repository.Product.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LtTask.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetProductList());
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost("product/create")]
        public async Task<IActionResult> CreateProduct([FromBody] Product model)
        {
            var categoryExists = await CategoryExists(model.CategoryId);

            if (!categoryExists)
            {
                return BadRequest("Category does not exist.");
            }

            return Ok(await _productService.CreateProduct(model));
        }

        [HttpPost("product/{id}/update")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product model)
        {
            if (model.Id == 0) model.Id = id;

            var categoryExists = await CategoryExists(model.CategoryId);

            if (!categoryExists)
                return BadRequest("Category does not exist.");

            if (id != model.Id)
                return BadRequest("Please check model and endpoint Id.");


            return Ok(await _productService.UpdateProduct(id, model));
        }

        [HttpDelete("product/{id}/delete")]
        public async Task<IActionResult> DeleteProduct(int id, [FromBody] Product model)
        {
            return Ok(await _productService.DeleteProduct(id));
        }

        private async Task<bool> CategoryExists(int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);

            return category == null ? false : true;
        }
    }
}