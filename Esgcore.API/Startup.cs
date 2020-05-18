using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esgcore.Logic.Configuration;
using Esgcore.DB.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;

namespace Esgcore.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors()
                .AddControllers()
                .AddNewtonsoftJson()
                ;

            //services
            //    .AddMvc(options => { options.Filters.Add<ValidationFilter>(); })
            //    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateSectorValidator>())
            //    ;

            services
                .AddDatabase(_configuration.GetConnectionString("Database"))
                .AddLogic(_configuration)
                .AddMediatR(typeof(LogicServiceCollectionExtensions).Assembly)
               // .AddMessageBroker(_configuration.GetSection("MessageBrokerSettings"))
               // .AddBackgroundJobServer(_configuration.GetSection("BackgroundJobServerSettings"))
                ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app
                //.UseBackgroundJobServerDashboard()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                ;
        }
    }
}
