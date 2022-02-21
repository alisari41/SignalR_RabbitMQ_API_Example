using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_RabbitMQ_API_Example
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Cros Politikasý
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(x => true))); 
            //Controllers eklendi
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Cors çaðýr
            app.UseCors();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Controllers eklendi
                endpoints.MapControllers();
            });
        }
    }
}
