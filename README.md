# SimpleEShop

The main idea of the view model composition is taken from [Mauro Servienti's implementation](https://github.com/mauroservienti/microservices-done-right-demos).

The code samples provided here are a simplified version of the composition engine. 

The example here shows Server-Side UI Composition by taking advantage of ASP NET Core's, `IAsyncResultFilter` to tie into the rendering pipeline of the view. 

The example also utilizes the `ExpandoObject` and `dynamic` to compose the view model. Useful link: http://www.siddharthpandey.net/use-newtonsoft-json-dynamic-expandoobject-objects/

The example uses Json Serialization for the data. 

The first part, [CompositionWithoutEvents](https://github.com/indualagarsamy/SimpleEShop/tree/master/CompositionWithoutEvents) demonstrates a simple UI composition where data from multiple services are composed during a HTTP Get request. The second part, [CompositionWithEvents](https://github.com/indualagarsamy/SimpleEShop/tree/master/CompositionWithEvents) demonstrates adding messages using NServiceBus.


## Suggestions for improvement

Any suggestions to improve this are welcome. Feel free to raise PRs or issues to make this better. 



 
