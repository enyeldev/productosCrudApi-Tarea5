using Microsoft.AspNetCore.Mvc;
using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using ProductoCRUD.Common.Response;
using ProductosCRUD.Application.Interfaces;


namespace ProdcutosCRUD.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServies _services;

        public ProductController(IProductServies services)
        {
            _services = services;
        }


        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<Response<List<ProductDto>>>> GetAllProducts()
        {
            return await _services.GetAllProducts();
        }

        [HttpPost("CreateNewProduct")]
        public async Task<ActionResult<Response<ProductDto>>> CreateNewProduct(CreateNewProductRequest request)
        {
            return await _services.CreateNewProduct(request);
        }

        [HttpPut("EditProduct/{id:int}")]
        public async Task<ActionResult<Response<ProductDto>>> EditProduct(int id, EditProductRequest request)
        {
            return await _services.EditProduct(id, request);

        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<ActionResult<Response<ProductDto>>> DeleteProduct(int id)
        {
            return await _services.DeleteProduct(id);
        }

    }
}
