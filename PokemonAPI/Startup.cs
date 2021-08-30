using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PokemonAPI.App;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using PokemonAPI.Application;

namespace PokemonAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var jsonSerializerSettings = new JsonSerializerSettings();

            WebJsonSerializerSettings.Apply(jsonSerializerSettings);
            JsonConvert.DefaultSettings = () => jsonSerializerSettings;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PokemonAPI", Version = "v1" });
                c.DescribeAllParametersInCamelCase();
            });
            services
                .AddMvc(config =>
                {
                    config.ModelBinderProviders.Insert(0, new CustomIModelBinderProvider());
                })
                .AddJsonOptions(options =>
                {
                   WebJsonSerializerSettings.Apply(new JsonSerializerSettings());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Application.DependencyInjection).Assembly));
            services.AddApplication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokemonAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{name}");
                endpoints.MapAreaControllerRoute(name: "Main", areaName: "Main", pattern: "{controller=Home}/{action=Index}/{name?}");
            });
        }
    }
}
