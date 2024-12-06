
using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using ProductoCRUD.Common.Response;
using ProductosCRUD.Application.Interfaces;
using ProductosCRUD.Infrastructure.Interfaces;


namespace ProductosCRUD.Application.Services
{
    public class ProductServices : IProductServies
    {

        private readonly IProductRepository _repo;

        public ProductServices(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<Response<ProductDto>>  CreateNewProduct(CreateNewProductRequest request)
        {
            if (request.Name == "" || request.Price == 0 || request.Stock == 0)
            {
                return new Response<ProductDto> { Code = 400, Message = "Todos los campos son requeridos" };
            }

            await _repo.CreateNewProduct(request);

            return new Response<ProductDto> { Code = 200, Message = "Nuevo producto agregado" };
        }

        public async Task<Response<ProductDto>> DeleteProduct(int id)
        {
            var deltedProduct = await _repo.GetProduct(id);

            if (deltedProduct is null)
            {
                return new Response<ProductDto> { Code = 404, Message = "No existe ese producto" };
            }

            await _repo.DeleteProduct(deltedProduct);

            return new Response<ProductDto> { Code = 200, Message = "Producto elimiando correctamente" };
        }

        public async Task<Response<ProductDto>> EditProduct(int id, EditProductRequest request)
        {
            var editedProduct = await _repo.GetProduct(id);

            if (editedProduct is null)
            {
                return new Response<ProductDto> { Code = 404, Message = "No existe ese producto" };
            };

            await _repo.UpdateProduct(editedProduct, request);

            return new Response<ProductDto> { Code = 200 , Message = "Producto actualizado correctamente" }; 
        }

        public async Task<Response<List<ProductDto>>> GetAllProducts()
        {
            var products = await _repo.GetProducts();

            if (products is null || products.Any())
            {
                return new Response<List<ProductDto>> { Code = 404, Message = "No hay productos" };
            }

            return new Response<List<ProductDto>> { Code = 200, Message = "Productso encontrados", Data = products, Succsess = true };
        }
    }
}
