using System;
using System.Reflection;
using Flight.Api.Domain.FlightSubscriptions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shared.Services.Avinor;

namespace Flight.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Avinor.Api", Version = "v1" });
            });
            services.AddMediatR(Assembly.GetAssembly(typeof(Startup)));
            services.AddHttpClient<IAvinorApiClient, AvinorApiClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("Endpoints:Avinor"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: Cors,
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });

            services.AddApplicationInsightsTelemetry();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(c =>
                {
                    c.TokenValidationParameters.ValidAudiences = new[]
                    {
                        Configuration.GetValue<string>("AzureAd:Audience")
                    };
                    c.Authority = $"https://login.microsoftonline.com/{Configuration.GetValue<string>("AzureAd:TenantId")}";
                });

            services.AddScoped<IServiceBus, ServiceBus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Avinor.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(Cors);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
            });
        }
    }
}
