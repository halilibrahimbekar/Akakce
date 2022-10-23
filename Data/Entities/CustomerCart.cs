using Service.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("customercart")]
    public class CustomerCart : BaseEntity
    {
        /// <summary>
        /// Müşteri Id'si
        /// </summary>
        [Required]
        [Column("customerid")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Ürün Id'si
        /// </summary>
        [Required]
        [Column("productid")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Ürün Adeti
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        [Column("count")]
        public int Count { get; set; }
    }
}
