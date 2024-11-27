using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCRUD.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProducts();

        Task CreateNewProduct(CreateNewProductRequest request);

        Task<ProductDto> GetProduct(int id);

        Task UpdateProduct(ProductDto productDto, EditProductRequest request);

        Task DeleteProduct(ProductDto productDto);
    }
}
