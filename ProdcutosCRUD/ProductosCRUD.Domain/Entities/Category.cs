
using ProductosCRUD.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdcutosCRUD.Domain.Entities
{
    public class Category : BaseEntity
    {
        
        public string Name { get; set; } = "";

        public bool IsDeleted { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
