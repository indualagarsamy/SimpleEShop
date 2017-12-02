using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Api.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool InStock { get; set; }
    }
}
