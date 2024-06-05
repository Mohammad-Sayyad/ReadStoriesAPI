using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadStoriesAPI.Models.Dto;
using ReadStoriesAPI.Repositoy.IRepository;

namespace ReadStoriesAPI.Contorllers
{
    [Route("api/CategoryAPI")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {

        private readonly ICategoryRepository _categpryRep;

        public CategoryAPIController(ICategoryRepository productRep)
        {
            _categpryRep = productRep;
        }

        
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesProduct()
        {
            var categoriesProducts = await _categpryRep.GetCategoriesProducts();

            if (categoriesProducts is null) return NotFound("Categories not found");

            return Ok(categoriesProducts);
        }


        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _categpryRep.GetById(id);

            if (category is null) return NotFound("Category not found");

            return Ok(category);
        }

    }
}
