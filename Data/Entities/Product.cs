using Service.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("product")]
    public class Product : BaseEntity
    {
        /// <summary>
        /// Ürün Adı
        /// </summary>
        [Required]
        [Column("productname")]
        public string ProductName { get; set; }
    }
}
