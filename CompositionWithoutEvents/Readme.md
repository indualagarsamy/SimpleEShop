# SimpleEShop

The main idea of the view model composition is taken from [Mauro Servienti's implementation](https://github.com/mauroservienti/microservices-done-right-demos).

This solution demonstrates server level UI composition where data from multiple services are composed during a HTTP Get request and shown in the View for the user. 

## Requisites

All projects in this solution use .NET Core. Please ensure that you have the latest SDK installed for .NET 2.0

### .NET Core WebApis

The solution has three WebApis namely Marketing.Api, Sales.Api and WareHouse.Api. These projects works with a in-memory EntityFramework database to have data initialized and retrieved based on ProductId.

### SimpleShop.UI

This is a ASP.NET MVC Core 2.0 web application. It references the two projects that provide the foundation with the view model composition and also each service's view model composition handlers.

#### ITOps.ViewModelComposition

By using dependency injection, we are able to create service related handlers, that the custom result filter can invoke based on the controller action. It exposes two public interfaces namely `IInterceptRoutes` and `IHandleRequests`. Each service can implement these interfaces. The implementations of these interfaces are registered in the container.  

The `CompositionHandler` class in the project, essentially matches the routes, requests to its different implementations registered in the container and calls each individual implementation that's necessary for the composition. 

#### ITOps.ViewModelComposition.Mvc

Implements a custom action filter. Filters are invoked right before the ASP MVC view engine renders the view. By implementing the `IAsyncResultFilter`, we can control the pipeline and control how we retrieve the data from various services before this data is rendered in the view. Invokes the `CompositionHandler.HandleRequest` in the implementation to get the collection of the right handlers to invoke to get the data. This custom result filter is registered at startup. 

### Service.ViewModelComposition

Each service implements its view model composition handler by implementing the `IHandleRequests` interface. The Matches method specifies when it should be invoked, for example, if the Request is a Http.Get and the controller is `product` and the action is `details`.

The `Handle` method has the actual implementation where it invokes the WebApi to retrieve the data required for the UI. It adds to the ExpandoObject its portion of the data that needs to be exposed to the view.  

## Suggestions for improvement

Any suggestions to improve this are welcome. Feel free to raise PRs or issues to make this better. 