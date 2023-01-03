using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public IActionResult Add(Cart cart)
        {
            _cartService.Add(cart);
            return Ok("Ürün sepete eklendi.");
        }

        [HttpPost("delete")]
        public IActionResult Delete(Cart cart)
        {
            _cartService.Delete(cart);
            return Ok("Ürün sepete eklendi.");
        }

        [HttpPost("update")]
        public IActionResult Update(Cart cart)
        {
            _cartService.Update(cart);
            return Ok("Ürün sepete eklendi.");
        }

        [HttpPost("getlist")]
        public IActionResult GetList()
        {
            var result= _cartService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cartService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }
}
