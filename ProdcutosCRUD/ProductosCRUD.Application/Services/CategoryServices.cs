using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using ProductoCRUD.Common.Response;
using ProductosCRUD.Application.Interfaces;
using ProductosCRUD.Infrastructure.Interfaces;


namespace ProductosCRUD.Application.Services
{
    public class CategoryServices : ICategoryServices
    {

        private readonly ICategoryRepository _repo;

        public CategoryServices(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Response<CategoryDto>> CreateCategory(CreateCategoryRequest request)
        {
            if (request.Name.Equals(""))
            {
                return new Response<CategoryDto>
                {
                    Code = 400,
                    Message = "Todos los campos son requeridos",
                };
            }

            await _repo.CreateNewCategory(request);

            return new Response<CategoryDto>
            {
                Code = 200,
                Message = "Nueva categoria creada",
                Succsess = true
            };
        }

        public async Task<Response<CategoryDto>> DeleteCategory(int id)
        {
            var categoryDelted = await _repo.GetCategory(id);

            if (categoryDelted is null)
            {
                return new Response<CategoryDto> { Code = 404, Message = "No existe esa categoria" };
            }

            await _repo.DeleteCategory(categoryDelted);

            return new Response<CategoryDto> { Code = 200, Message = "Categoria eliminada", Succsess = true };
        }

        public async Task<Response<CategoryDto>> EditCategory(int id, EditCategoryRequest request)
        {
            var categoryExist = await _repo.GetCategory(id);

            if (categoryExist is null)
            {
                return new Response<CategoryDto> { Code = 404, Message = "No existe esa categoria" };
            }

            if (request.Name.Equals(""))
            {
                return new Response<CategoryDto> { Code = 400, Message = "Todos los campos son requeridos" };
            }

            await _repo.UpdateCategory(categoryExist, request);

            return new Response<CategoryDto> { Code = 200, Message = "Categoria editada correctamente", Succsess = true };
        }

        public async Task<Response<List<CategoryDto>>> GetAllCategories()
        {
            var categories = await _repo.GetCategories();


            if (categories.Any() || categories is null)
            {
                return new Response<List<CategoryDto>>
                {
                    Code = 404,
                    Message = "No se encontraron categorias",
                };
            };

            return new Response<List<CategoryDto>>
            {
                Code = 200,
                Data = categories,
                Message = "Categorias encontradas",
                Succsess = true
            };
        }
    }
}
