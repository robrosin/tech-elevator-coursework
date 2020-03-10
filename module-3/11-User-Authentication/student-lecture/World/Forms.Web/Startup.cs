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
using TE.AuthLib;
using TE.AuthLib.DAL;

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
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /********* Session Setup  *************/
            services.AddDistributedMemoryCache();
            services.AddSession();

            /**** DEPENDENCY INJECTION *****/
            // First, find the connection string in AppSettings.json using the Configuration object
            // TODO 01 (Startup): Show connection strings for World and User in appsettings.json 
            connectionString = Configuration.GetConnectionString("World");
            string userConnectionString = Configuration.GetConnectionString("User");

            // Then tell the DI Container what "implementation" to create whenever it is asked for a "service"

            // This is how you will normally see this implemented...
            //            services.AddTransient<ICityDAO, CitySqlDAO>((x) => new CitySqlDAO(connectionString));

            // But this is what is really happening.  A reference to a method which creates the DAO is paased into
            // the AddTransient method.
            services.AddTransient<ICityDAO, CitySqlDAO>(MakeNewCityDAO);

            // Setup DI for CountryDAO
            services.AddTransient<ICountryDAO, CountrySqlDAO>((x) => new CountrySqlDAO(connectionString));

            // TODO 01 (Startup): Set up DI for the User object for authentication
            services.AddTransient<IUserDAO>(m => new UserSqlDAO(userConnectionString));

            // TODO 01 (Startup): Setup dependency injection for the authentication provider
            //            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-context?view=aspnetcore-3.1

            services.AddHttpContextAccessor();
            services.AddScoped<IAuthProvider, SessionAuthProvider>();

            // TODO 01 (Startup): Configure the Auth filter to re-direct to account/login
            AuthorizeAttribute.Options = new AuthorizeAttribute.AuthorizeAttributeOptions()
            {
                LoginRedirectAction = "Login",
                LoginRedirectController = "Account"
            };

            // Globally add auto-validation for all controllers and post methods
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            /********* Session Setup  *************/
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
