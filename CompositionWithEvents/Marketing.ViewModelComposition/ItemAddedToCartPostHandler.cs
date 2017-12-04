using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ITOps.ViewModelComposition;
using Marketing.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using NServiceBus;

namespace Marketing.ViewModelComposition
{
    public class ItemAddedToCartPostHandler : IHandleRequests
    {
        private IMessageSession session;
        public ItemAddedToCartPostHandler(IMessageSession messageSession)
        {
            session = messageSession;
        }
        public bool Matches(RouteData routeData, string httpVerb, HttpRequest request)
        {
            //determine if the incoming request should 
            //be composed with Marketing data, e.g.
            var controller = (string)routeData.Values["controller"];
            var action = (string)routeData.Values["action"];

            return HttpMethods.IsPost(httpVerb)
                   && controller.ToLowerInvariant() == "products"
                   && action.ToLowerInvariant() == "addToCart"
                   && routeData.Values.ContainsKey("id");
        }

        public async Task Handle(dynamic vm, RouteData routeData, HttpRequest request)
        {
            await session.Send(new AddProductItemToCart() {ProductId = vm.productId});
        }
    }
}
