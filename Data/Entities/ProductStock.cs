using Service.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("productstock")]
    public class ProductStock : BaseEntity
    {
        /// <summary>
        /// Stok Adedi
        /// </summary>
        [Required]
        [Column("stock")]
        public int Stock { get; set; }

        /// <summary>
        /// Ürün
        /// </summary>
        [Required]
        [Column("productid")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ürün
        /// </summary>
        public virtual Product Product { get; set; }

    }
}
