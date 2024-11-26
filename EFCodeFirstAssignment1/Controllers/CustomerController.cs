using EFCodeFirstAssignment1.Interface;
using EFCodeFirstAssignment1.Model;
using EFCodeFirstAssignment1.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirstAssignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerServices;
        public CustomerController(ICustomer customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customer = await _customerServices.GetAllCustomer();
            if (customer is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(customer);
        }
       
        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetCustomerByID(int id)
        {
            try
            {
                var customer = await _customerServices.GetCustomerByID(id);
                if (customer == null)
                    return NotFound("Record Not Found");
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveCustomer(Customer customerModel)
        {
            try
            {
                var model = await _customerServices.AddCustomer(customerModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var model = await _customerServices.DeleteCustomerByID(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
