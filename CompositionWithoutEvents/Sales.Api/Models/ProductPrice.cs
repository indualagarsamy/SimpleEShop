using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Api.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
