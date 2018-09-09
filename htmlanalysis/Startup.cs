using System.Net.Http;
using HTMLAnalysis.Domain;
using HTMLAnalysis.Domain.Documents;
using HTMLAnalysis.Domain.Encryption;
using HTMLAnalysis.Domain.Fetches;
using HTMLAnalysis.Domain.Frequencies;
using HTMLAnalysis.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HTMLAnalysis
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
            services.AddTransient<HttpClient>()
                    .AddTransient<IDocumentService, DocumentService>()
                    .AddTransient<IFetchService, FetchService>()
                    .AddTransient<IFetchRepository, FetchRepository>()
                    .AddTransient<IFrequencyRepository, FrequencyRepository>()
                    .AddTransient<IEncryptionService, EncryptionService>()
                    .AddTransient<IFrequencyAdapter, FrequencyAdapter>();

            services.AddEntityFrameworkMySql()
                    .AddDbContext<WebFrequenciesDbContext>(options =>
                    {
                        options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
                    });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}