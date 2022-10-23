using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akakce.Data
{
    public class AkakceContext : DbContext
    {
        #region Ctor
        public AkakceContext(DbContextOptions<AkakceContext> options)
            : base(options)
        {
        }
        #endregion

        #region Entities
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductStock> ProductStocks { get; set; }

        public DbSet<CustomerCart> CustomerCarts { get; set; }
        #endregion
    }
}
