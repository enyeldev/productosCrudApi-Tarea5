using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProdcutosCRUD.Common.Request;
using ProdcutosCRUD.Domain.Entities;
using ProdcutosCRUD.Persistence;
using ProductoCRUD.Common.Dtos;
using ProductosCRUD.Infrastructure.Interfaces;

namespace ProductosCRUD.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductoCrudDbContext _context;
        private readonly IMapper _productMapper;
        public ProductRepository(ProductoCrudDbContext context, IMapper productMapper)
        {
            _context = context;
            _productMapper = productMapper;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _context.Products.Where(e => e.IsDeleted == false).ToListAsync();
            var productsToReturn = new List<ProductDto>();

            foreach (var product in products)
            {
                productsToReturn.Add(_productMapper.Map<ProductDto>(product));
            }

            return productsToReturn;
        }

        public async Task CreateNewProduct(CreateNewProductRequest request)
        {
            var newProduct = new Product();

            newProduct.Name = request.Name;
            newProduct.Price = request.Price;
            newProduct.Stock = request.Stock;
            newProduct.CategoryId = request.CategoryId;

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _context.Products.FirstAsync(e => e.Id == id);

            var productDto = _productMapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task UpdateProduct(ProductDto productDto, EditProductRequest request)
        {
            var editProduct = _productMapper.Map<Product>(productDto);

            editProduct.Name = request.Name;
            editProduct.Price = request.Price;
            editProduct.Stock = request.Stock;
            editProduct.CategoryId = request.CategoryId;

            _context.Products.Update(editProduct);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(ProductDto productDto)
        {
            var deleteProduct = _productMapper.Map<Product>(productDto);

            deleteProduct.IsDeleted = true;
            _context.Products.Update(deleteProduct);

            await _context.SaveChangesAsync();
        }

    }
}
