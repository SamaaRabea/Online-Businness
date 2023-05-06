using Microsoft.AspNetCore.Mvc;
using Shope.BL;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesManagers _categoriesManager;
        public CategoriesController(ICategoriesManagers categoriesManager)
        {
            _categoriesManager = categoriesManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoriesDTO>> GetAllCategories()
        {
            return _categoriesManager.GetAllCategories();
        }
        
        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<CategoriesDTO> GetCategoryById(Guid id)
        {
            var categoryDTO = _categoriesManager.GetCategoryById(id);

            if (categoryDTO == null)
            {
                return NotFound();
            }

            return categoryDTO;
        }

        [HttpPost]
        public IActionResult AddCategory(CategoriesDTO categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data provided." });
            }
            _categoriesManager.AddCategory(categories);
            return Ok(new { message = "Category added successfully." });
        }

        [HttpPut]
        public IActionResult PutCategory(CategoriesDTO category)
        {
            _categoriesManager.EditCategory(category);
            return Ok(new { message = "category Edited successfully." });

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(Guid id)
        {
            _categoriesManager.Delete(id);
            return NoContent();
        }
    }
}
