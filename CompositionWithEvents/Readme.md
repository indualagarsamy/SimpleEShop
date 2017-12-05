# SimpleEShop

The main idea of the view model composition is taken from [Mauro Servienti's implementation](https://github.com/mauroservienti/microservices-done-right-demos).

This solution demonstrates server level UI composition where data from multiple services are composed during a HTTP Post request and uses [NServiceBus](https://docs.particular.net/get-started) to dispatch messages.

For how UI Composition works, [see the previous sample](https://github.com/indualagarsamy/SimpleEShop/tree/master/CompositionWithoutEvents/readme.md).

## NServiceBus Setup

As all projects in this solution uses .NET Core, the NServiceBus version used in a pre-release version which supports .NET Core. 

To get the latest version of NServiceBus pre-release for both the core and NServiceBus.Newtonsoft.Json, 
use the [MyGet feed](https://www.myget.org/F/particular/).

The NServiceBus samples also use the learning transport. This is not a production ready transport. This transport merely serves the purpose of demonstrating the NServiceBus API. For production purposes, please use one of the [supported transports](https://docs.particular.net/transports/).

## SimpleShop.UI

The NServiceBus bootstrapping is done in both `SimpleShop.UI` and the `IMessageSession` is registered in the container. This interface is then used by the ViewModelComposition projects to retrieve it from the container and use it to send messages. 

## Marketing.ViewModelComposition

This project shows a HTTP Post composition by implementing a `IHandleRequests` for the `Add To Cart` post action. In its implementation, it uses the injected IMessageSession to send a message to the Marketing.Api back-end.

## Marketing.Api

This is a .NET Core Web API and a NServiceBus endpoint. NServiceBus is bootstrapped on Startup. It handles messages of type `AddProductItemToCart`

## Marketing.Messages

This is the schema of the messages for the Marketing Service. This sample uses a message called, `AddProductItemToCart`. The schema needs to be shared with both the sender and the receiver of the message.

## Suggestions for improvement

Any suggestions to improve this are welcome. Feel free to raise PRs or issues to make this better. 

