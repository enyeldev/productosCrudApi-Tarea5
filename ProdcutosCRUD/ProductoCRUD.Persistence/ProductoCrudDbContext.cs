using Microsoft.EntityFrameworkCore;
using ProdcutosCRUD.Domain.Entities;




namespace ProdcutosCRUD.Persistence
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
