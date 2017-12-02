using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Api.Models;

namespace Warehouse.Api.Controllers
{
    [Route("product")]
    public class StockItemsStatusController : Controller
    {
        private readonly StockItemContext context;

        public StockItemsStatusController(StockItemContext context)
        {
            this.context = context;

            if (!context.StockItems.Any())
            {
                context.StockItems.Add(new StockItem() {Id = 1, InStock = true, ProductId = 1});
                context.SaveChanges();
            }
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(long id)
        {
            var item = context.StockItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
