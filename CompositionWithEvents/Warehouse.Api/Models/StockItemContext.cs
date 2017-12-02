using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Api.Models
{
    public class StockItemContext : DbContext
    {
        public StockItemContext(DbContextOptions<StockItemContext> stockItem)
            : base(stockItem)
        {
        }

        public DbSet<StockItem> StockItems { get; set; }

    }
}
