using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechElevator.Web.DAL;

namespace TechElevator.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Use Configuration to get a connection string to the database
            string connectionString = Configuration.GetConnectionString("Default");

            // Add Dependency Injection setup logic here for a Film DAO

            // "Listen framework, any time someone needs an IStarWarsDAO, I'm telling you
            // right here and now, create a StarWarsSqlDAO using this code, and give that to them."
            services.AddTransient<IStarWarsDAO, StarWarsSqlDAO>(
                // The parameter we are passing into AddTransient is a reference (pointer) to a method
                // which the framework should run at the time it needs a new StarWars DAO.  
                // This (anonymous) method is defined here:
                (x) =>
                {
                    return new StarWarsSqlDAO(connectionString);
                }
            );

            //You would normally see this abbreviated syntax using "expression body" syntax
            //services.AddTransient<IStarWarsDAO, StarWarsSqlDAO>(x => new StarWarsSqlDAO(connectionString));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
