using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketing.Api.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
