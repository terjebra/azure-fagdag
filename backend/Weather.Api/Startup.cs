using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Net.Http.Headers;
using System.Reflection;
using MediatR;
using Weather.Api.Domain.Yr;

namespace Weather.Api
{
    public class Startup
    {
        public string Cors = "Cors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather.Api", Version = "v1" });
            });
            services.AddMediatR(Assembly.GetAssembly(typeof(Startup)));

            services.AddHttpClient<IYrApiClient, YrApiClient>(client =>
            {
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("YrAPI","1.0"));
                client.BaseAddress = new Uri(Configuration.GetValue<string>("Endpoints:Yr"));
            });
            
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
