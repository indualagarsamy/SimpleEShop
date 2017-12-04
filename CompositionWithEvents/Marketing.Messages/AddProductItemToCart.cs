using System;
using NServiceBus;

namespace Marketing.Messages
{
    public class AddProductItemToCart : ICommand
    {
        public int ProductId { get; set; }
    }
}
