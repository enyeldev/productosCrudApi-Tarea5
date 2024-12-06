
using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using ProductoCRUD.Common.Response;


namespace ProductosCRUD.Application.Interfaces
{
    public interface IProductServies
    {

        Task<Response<List<ProductDto>>> GetAllProducts();

        Task<Response<ProductDto>> CreateNewProduct(CreateNewProductRequest request);

        Task<Response<ProductDto>> EditProduct(int id, EditProductRequest request);

        Task<Response<ProductDto>> DeleteProduct(int id);
    }
}
