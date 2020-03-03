using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forms.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string connectionString;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // TODO 04: Globally add auto-validation for all controllers and post methods


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            /**** DEPENDENCY INJECTION *****/
            // First, find the connection string in AppSettings.json using the Configuration object
            connectionString = Configuration.GetConnectionString("Default");

            // Then tell the DI Container what "implementation" to create whenever it is asked for a "service"

            // This is how you will normally see this implemented...
//            services.AddTransient<ICityDAO, CitySqlDAO>((x) => new CitySqlDAO(connectionString));

            // But this is what is really happening.  A reference to a method which creates the DAO is paased into
            // the AddTransient method.
            services.AddTransient<ICityDAO, CitySqlDAO>(MakeNewCityDAO);
        }

        // And here is the method that create a new CitySQLDAO
        public CitySqlDAO MakeNewCityDAO(IServiceProvider x)
        {
            return new CitySqlDAO(connectionString);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
