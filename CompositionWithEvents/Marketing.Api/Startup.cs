using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketing.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NServiceBus;

namespace Marketing.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductDetailsContext>(opt => opt.UseInMemoryDatabase("ProductDetailsList"));
            services.AddMvc();
            BootstrapNServiceBusForMessaging(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        void BootstrapNServiceBusForMessaging(IServiceCollection services)
        {

            var config = new EndpointConfiguration("Marketing.Api");
            config.UseSerialization<NewtonsoftSerializer>();
            config.UseTransport<LearningTransport>();
            config.SendFailedMessagesTo("error");
            var instance = Endpoint.Start(config).GetAwaiter().GetResult();
            services.AddSingleton<IMessageSession>(instance);

        }
    }
}
