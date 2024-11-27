using Microsoft.AspNetCore.Mvc;
using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using ProductosCRUD.Infrastructure.Interfaces;


namespace ProdcutosCRUD.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }


        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            return await _repo.GetCategories();
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult> CreateCategory(CreateCategoryRequest request)
        {
            if (request.Name.Equals(""))
            {
                return BadRequest("Todos los campos son requeridos");
            }

            await _repo.CreateNewCategory(request);

            return Ok(new { msg = "Nueva categoria agregada" });
        }

        [HttpPut("EditCategory/{id:int}")]
        public async Task<ActionResult> EditCategory(int id, EditCategoryRequest request)
        {

            var categoryExist = await _repo.GetCategory(id);

            if (categoryExist is null)
            {
                return BadRequest(new { msg = "No existe esa categoria" });
            }

            if (request.Name.Equals(""))
            {
                return BadRequest(new {msg = "Todos los campos son requeridos" });
            }

            await _repo.UpdateCategory(categoryExist, request);

            return Ok(new {msg = "Categoria editada correctamente" });
        }

        [HttpDelete("DeleteCategory/{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var categoryDelted = await _repo.GetCategory(id);

            if (categoryDelted is null)
            {
                return NotFound("No existe esa categoria");
            }

            await _repo.DeleteCategory(categoryDelted);

            return Ok(new {msg = "Categoria eliminada" });
        }
    }
}
