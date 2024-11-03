using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdcutosCRUD.Data;
using ProdcutosCRUD.Models.Entities;
using ProdcutosCRUD.Models.Request;

namespace ProdcutosCRUD.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ProductoCrudDbContext _context;

        public CategoryController(ProductoCrudDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return await _context.Categories.Where(e => e.IsDeleted == false).ToListAsync();
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult> CreateCategory(CreateCategoryRequest request)
        {
            if (request.Name.Equals(""))
            {
                return BadRequest("Todos los campos son requeridos");
            }

            var category = new Category();

            category.Name = request.Name;

             _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return Ok(new { msg = "Nueva categoria agregada" });
        }

        [HttpPut("EditCategory/{id:int}")]
        public async Task<ActionResult> EditCategory(int id, EditCategoryRequest request)
        {

            var categoryExist = await _context.Categories.FirstAsync(e => e.Id == id);

            if (categoryExist is null)
            {
                return BadRequest(new { msg = "No existe esa categoria" });
            }

            if (request.Name.Equals(""))
            {
                return BadRequest(new {msg = "Todos los campos son requeridos" });
            }

            categoryExist.Name = request.Name;

            _context.Categories.Update(categoryExist);
            await _context.SaveChangesAsync();

            return Ok(new {msg = "Categoria editada correctamente" });
        }

        [HttpDelete("DeleteCategory/{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var categoryDelted = await _context.Categories.FirstAsync(cat => cat.Id == id);

            if (categoryDelted is null)
            {
                return NotFound("No existe esa categoria");
            }

            categoryDelted.IsDeleted = true;

            _context.Categories.Update(categoryDelted);

            await _context.SaveChangesAsync();

            return Ok(new {msg = "Categoria eliminada" });
        }
    }
}
