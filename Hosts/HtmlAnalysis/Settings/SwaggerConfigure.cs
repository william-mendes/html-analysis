using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace HtmlAnalysis.Settings
{
    public static class SwaggerConfigure
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            var servicesProvider = services.BuildServiceProvider();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "HtmlAnalysis", Version = "v1" });
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        public static void AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "School V1");
            });
        }
    }
}