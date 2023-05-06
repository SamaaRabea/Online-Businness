using Microsoft.AspNetCore.Mvc;
using Shope.BL;

namespace Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            return _productManager.GetAllProducts();
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<ProductDTO> GetProductById(Guid id)
        {
            var productDTO = _productManager.GetProductById(id);

            if (productDTO == null)
            {
                return NotFound();
            }

            return productDTO;
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data provided." });
            }
            _productManager.AddProduct(product);
            return Ok(new { message = "Product added successfully." });
        }
        [HttpPut]
        public IActionResult PutProduct(ProductDTO product)
        {
           _productManager.EditProduct(product);
            return Ok(new { message = "Product Edited successfully." });

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            _productManager.Delete(id);
            return NoContent();
        }
    }
}
