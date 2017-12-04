using ITOps.ViewModelComposition;
using ITOps.ViewModelComposition.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

namespace SimpleEShop.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddViewModelComposition();
            services.AddMvc()
                .AddViewModelCompositionMvcSupport();
            BootstrapNServiceBusForMessaging(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }

        void BootstrapNServiceBusForMessaging(IServiceCollection services)
        {
            
                var config = new EndpointConfiguration("SimpleEShop.UI");
                config.UseSerialization<NewtonsoftSerializer>();
                config.UseTransport<LearningTransport>();
                config.SendFailedMessagesTo("error");
                var instance = Endpoint.Start(config).GetAwaiter().GetResult();
                services.AddSingleton<IMessageSession>(instance);
            
        }
    }
}
