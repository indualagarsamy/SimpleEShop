using Microsoft.EntityFrameworkCore;

namespace Sales.Api.Models
{
    public class ProductPriceContext : DbContext
    {
        public ProductPriceContext(DbContextOptions<ProductPriceContext> productDetails)
            : base(productDetails)
        {
        }

        public DbSet<ProductPrice> ProductPrices { get; set; }

    }
}
