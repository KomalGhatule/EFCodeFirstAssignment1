using EFCodeFirstAssignment1.Interface;
using EFCodeFirstAssignment1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirstAssignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistory _orderHistoryService;
        public OrderHistoryController(IOrderHistory orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var orderHistory = await _orderHistoryService.GetAllOrderHistory();
            if(orderHistory == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(orderHistory);
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult>Get(int id)
        {
            var orderHistory = await _orderHistoryService.GetOrderHistoryByID(id);
            if(orderHistory==null)
            {
                return NotFound("No Data Found");
            }
            return Ok(orderHistory);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveOrderHistory(OrderHistory obj)
        {
            try
            {
                var model = await _orderHistoryService.AddOrderHistory(obj);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteOrderHistory(int id)
        {
            try
            {
                var model = await _orderHistoryService.DeleteOrderHistoryByID(id);
                return Ok(model);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

    }
}
