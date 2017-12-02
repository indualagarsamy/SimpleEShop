using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketing.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marketing.Api.Controllers
{
    [Route("product")]
    public class TodoController : Controller
    {
        private readonly ProductDetailsContext context;

        public TodoController(ProductDetailsContext context)
        {
            this.context = context;

            if (!context.ProductDetails.Any())
            {
                context.ProductDetails.Add(new ProductDetails() {Description = "Coolest phone ever!! at least according to some!", Id=1, Name="iPhoneX", ProductId = 1});
                context.SaveChanges();
            }
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(long id)
        {
            var item = context.ProductDetails.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
