using EFCodeFirstAssignment1.Interface;
using EFCodeFirstAssignment1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirstAssignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderService;
        public OrderController(IOrder orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var order=await _orderService.GetAllOrders();
            if(order == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(order);
        }
        
        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
                return NotFound("No data Found");
            return Ok(order);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveOrder(Order obj)
        {
            try
            {
                var model = await _orderService.AddOrder(obj);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var model = await _orderService.DeleteOrderById(id);
                return Ok(model);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
