using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;   
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            _productService.Add(product);
            return Ok("Ürün eklendi");
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            _productService.Delete(product);
            return Ok("Ürün eklendi");
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);
            return Ok("Ürün eklendi");
        }

        [HttpPost("getlist")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
