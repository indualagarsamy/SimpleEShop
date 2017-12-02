using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Marketing.Api.Models
{
    public class ProductDetailsContext : DbContext
    {
        public ProductDetailsContext(DbContextOptions<ProductDetailsContext> productDetails)
            : base(productDetails)
        {
        }

        public DbSet<ProductDetails> ProductDetails { get; set; }

    }
}
