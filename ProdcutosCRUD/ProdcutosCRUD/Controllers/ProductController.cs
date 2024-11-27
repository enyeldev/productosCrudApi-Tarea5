using Microsoft.AspNetCore.Mvc;
using ProdcutosCRUD.Common.Request;
using ProductoCRUD.Common.Dtos;
using ProductosCRUD.Infrastructure.Interfaces;
using ProductosCRUD.Infrastructure.Repositories;

namespace ProdcutosCRUD.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }


        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            return await _repo.GetProducts();
        }

        [HttpPost("CreateNewProduct")]
        public async Task<ActionResult> CreateNewProduct(CreateNewProductRequest request)
        {
            if (request.Name == "" || request.Price == 0 || request.Stock == 0)
            {
                return BadRequest(new { msg = "Todos los campos son requeridos" });
            }

             await _repo.CreateNewProduct(request);

            return Ok(new { msg = "Nuevo producto agregado" });
        }

        [HttpPut("EditProduct/{id:int}")]
        public async Task<ActionResult> EditProduct(int id, EditProductRequest request)
        {
            var editedProduct = await _repo.GetProduct(id);

            if (editedProduct is null)
            {
                return NotFound(new { msg = "No existe ese producto" });
            };

            await _repo.UpdateProduct(editedProduct, request);
            
            return Ok(new { msg = "Producto actualizado correctamente" });

        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var deltedProduct = await _repo.GetProduct(id);

            if (deltedProduct is null)
            {
                return NotFound(new { msg = "No existe ese producto" });
            }

            await _repo.DeleteProduct(deltedProduct);

            return Ok(new { msg = "Producto elimiando correctamente" });
        }

    }
}
