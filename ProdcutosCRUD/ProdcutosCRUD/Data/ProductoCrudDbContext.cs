using Microsoft.EntityFrameworkCore;
using ProdcutosCRUD.Models.Entities;

namespace ProdcutosCRUD.Data
{
    public class ProductoCrudDbContext : DbContext
    {
        public ProductoCrudDbContext(DbContextOptions options) : base(options)
        {
        }

        
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
