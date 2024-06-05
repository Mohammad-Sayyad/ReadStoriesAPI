using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadStoriesAPI.Models.Dto;
using ReadStoriesAPI.Repositoy.IRepository;

namespace ReadStoriesAPI.Contorllers
{
    [Route("api/ProductAPI")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductRepository _productRep;

        public ProductAPIController(IProductRepository productRep)
        {
            _productRep = productRep;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _productRep.GetAll();
            if (products is null) return NotFound("Products not found");
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _productRep.GetById(id);
            if (product is null) return NotFound("Product not found");
            return Ok(product);
        }

    }
}
