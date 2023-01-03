using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            _orderService.Add(order);
            return Ok("Ürün eklendi");
        }

        [HttpPost("delete")]
        public IActionResult Delete(Order order)
        {
            _orderService.Delete(order);
            return Ok("Ürün eklendi");
        }

        [HttpPost("update")]
        public IActionResult Update(Order order)
        {
            _orderService.Update(order);
            return Ok("Ürün eklendi");
        }

        [HttpPost("getlist")]
        public IActionResult GetList()
        {
            var result = _orderService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }




    }
}
