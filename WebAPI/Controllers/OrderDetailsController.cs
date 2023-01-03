using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }


        [HttpPost("add")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            _orderDetailService.Add(orderDetail);
            return Ok("Ürün eklendi");
        }

        [HttpPost("delete")]
        public IActionResult Delete(OrderDetail orderDetail)
        {
            _orderDetailService.Delete(orderDetail);
            return Ok("Ürün eklendi");
        }

        [HttpPost("update")]
        public IActionResult Update(OrderDetail orderDetail)
        {
            _orderDetailService.Update(orderDetail);
            return Ok("Ürün eklendi");
        }

        [HttpPost("getlist")]
        public IActionResult GetList()
        {
            var result = _orderDetailService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _orderDetailService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }







    }
}
