using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketing.Messages;
using NServiceBus;

namespace Marketing.Api
{
    public class AddProductItemToCartHandler : IHandleMessages<AddProductItemToCart>
    {
        public Task Handle(AddProductItemToCart message, IMessageHandlerContext context)
        {
            // Do something meaningful
            return Task.CompletedTask;
        }
    }
}
