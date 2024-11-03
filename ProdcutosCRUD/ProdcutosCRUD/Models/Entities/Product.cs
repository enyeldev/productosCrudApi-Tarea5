using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdcutosCRUD.Models.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int Stock { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }


    }
}
