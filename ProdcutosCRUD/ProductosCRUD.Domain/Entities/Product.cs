using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProductosCRUD.Domain.Core;


namespace ProdcutosCRUD.Domain.Entities
{
    public class Product : BaseEntity
    {
        
        public string Name { get; set; } = "";

        public int Stock { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }


    }
}
