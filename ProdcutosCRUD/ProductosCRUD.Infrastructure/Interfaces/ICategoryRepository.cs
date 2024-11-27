using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCRUD.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {

        Task<List<CategoryDto>> GetCategories();

        Task CreateNewCategory(CreateCategoryRequest request);

        Task UpdateCategory(CategoryDto categoryDto, EditCategoryRequest request);

        Task DeleteCategory(CategoryDto categoryDto);

        Task<CategoryDto> GetCategory(int id);

    }
}
