using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdcutosCRUD.Data;
using ProdcutosCRUD.Models.Entities;
using ProdcutosCRUD.Models.Request;

namespace ProdcutosCRUD.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductoCrudDbContext _context;

        public ProductController(ProductoCrudDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return await _context.Products.Where(e => e.IsDeleted == false).ToListAsync();
        }

        [HttpPost("CreateNewProduct")]
        public async Task<ActionResult> CreateNewProduct(CreateNewProductRequest request)
        {
            if (request.Name == "" || request.Price == 0 || request.Stock == 0)
            {
                return BadRequest(new {msg = "Todos los campos son requeridos" });
            }

            var newProduct = new Product();

            newProduct.Name = request.Name;
            newProduct.Price = request.Price;
            newProduct.Stock = request.Stock;
            newProduct.CategoryId = request.CategoryId;

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return Ok(new {msg = "Nuevo producto agregado" });
        }

        [HttpPut("EditProduct/{id:int}")]
        public async Task<ActionResult> EditProduct(int id, EditProductRequest request)
        {

            var editedProduct = await _context.Products.FirstAsync(e => e.Id == id);

            if (editedProduct is null)
            {
                return NotFound(new {msg = "No existe ese producto" });
            };


            editedProduct.Name = request.Name;
            editedProduct.Price = request.Price;
            editedProduct.Stock = request.Stock;
            editedProduct.CategoryId = request.CategoryId;

            _context.Products.Update(editedProduct);

            await _context.SaveChangesAsync();

            return Ok(new {msg = "Producto actualizado correctamente" });

        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var deltedProduct = await _context.Products.FirstAsync(e => e.Id == id);

            if (deltedProduct is null)
            {
                return NotFound(new {msg = "No existe ese producto" });
            }

            deltedProduct.IsDeleted = true;
            _context.Products.Update(deltedProduct);

            await _context.SaveChangesAsync();
            return Ok(new {msg = "Producto elimiando correctamente" });
        }

    }
}
