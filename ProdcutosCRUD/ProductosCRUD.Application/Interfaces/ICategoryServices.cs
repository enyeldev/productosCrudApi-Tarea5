using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using ProductoCRUD.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCRUD.Application.Interfaces
{
    public interface ICategoryServices
    {
       Task<Response<List<CategoryDto>>> GetAllCategories();

        Task<Response<CategoryDto>> CreateCategory(CreateCategoryRequest request);

        Task<Response<CategoryDto>> EditCategory(int id, EditCategoryRequest request);

        Task<Response<CategoryDto>> DeleteCategory(int id);
    }
}
