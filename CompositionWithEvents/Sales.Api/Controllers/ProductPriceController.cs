using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;

namespace Sales.Api.Controllers
{
    [Route("product")]
    public class ProductPriceController : Controller
    {
        private readonly ProductPriceContext context;

        public ProductPriceController(ProductPriceContext context)
        {
            this.context = context;

            if (!context.ProductPrices.Any())
            {
                context.ProductPrices.Add(new ProductPrice() {Id = 1, Price = new decimal(1095.00), ProductId = 1});
                context.SaveChanges();
            }
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(long id)
        {
            var item = context.ProductPrices.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }

}
