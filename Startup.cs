using System;
using System.IO;
using System.Reflection;
using CS201_WebApi.Extensions;
using CS201_WebApi.Features.Todo;
using CS201_WebApi.Features.User;
using CS201_WebApi.Infra.Http;
using CS201_WebApi.Infra.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CS201_WebApi
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
            Action<DbContextOptionsBuilder> defaultContextConfig = optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(Configuration["database"], sqlServerOptionsBuilder => 
                {
                    sqlServerOptionsBuilder.CommandTimeout(1000);
                });
            };

            services
                .AddScoped(typeof(TodoService))
                .AddScoped(typeof(TodoRepository))
                .AddDbContextPool<TodoContext>(defaultContextConfig)
                .AddDbContextPool<UserContext>(defaultContextConfig);

            services
                .AddControllers(options => 
                {
                    options.Conventions.Add(new KebabCaseRoutesConvention());
                    // options.Filters.Add(new ValidateModelFilter());
                    options.Filters.Add(new HttpResponseExceptionFilter());
                })
                // For PATCH action with JsonPatchDocument:
                .AddNewtonsoftJson();

            services
                .AddSwaggerGen(c => 
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
                    { 
                        Title = "CS201 WebApi",
                        Version = "v1",
                        Description = "Simple example of an WebApi created with ASP.NET Core"
                    });

                    // For XML comments for detailing of controllers and routes:
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseMiddleware<RequestLoggingMiddleware>()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CS201 WebApi V1");
                });
        }
    }

    internal class KebabCaseRoutesConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                controller.ControllerName = controller.ControllerName.PascalToKebabCase();

                foreach (var action in controller.Actions)
                    action.ActionName = action.ActionName.PascalToKebabCase();
            }
        }
    }
}
