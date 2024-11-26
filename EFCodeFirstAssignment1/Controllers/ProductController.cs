using EFCodeFirstAssignment1.Interface;
using EFCodeFirstAssignment1.Model;
using EFCodeFirstAssignment1.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCodeFirstAssignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productServices;

        public ProductController(IProduct productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _productServices.GetAllProduct();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetProductByID(int id)
        {

            var product = await _productServices.GetProductByID(id);
            if (product == null)
                return NotFound("Record Not Found");
            return Ok(product);

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveProduct(Product obj)
        {
            try
            {
                var model = await _productServices.AddProduct(obj);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var model = await _productServices.DeleteProductByID(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
