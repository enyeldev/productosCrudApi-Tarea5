using Microsoft.AspNetCore.Mvc;
using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using ProductoCRUD.Common.Response;
using ProductosCRUD.Application.Interfaces;


namespace ProdcutosCRUD.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }


        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<Response<List<CategoryDto>>>> GetAllCategories()
        {
            return await _services.GetAllCategories();
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Response<CategoryDto>>> CreateCategory(CreateCategoryRequest request)
        {
            return await _services.CreateCategory(request);
        }

        [HttpPut("EditCategory/{id:int}")]
        public async Task<ActionResult<Response<CategoryDto>>> EditCategory(int id, EditCategoryRequest request)
        {
          return await _services.EditCategory( id,request);
        }

        [HttpDelete("DeleteCategory/{id:int}")]
        public async Task<ActionResult<Response<CategoryDto>>> DeleteCategory(int id)
        {
            return await  _services.DeleteCategory(id);
        }
    }
}
