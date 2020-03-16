﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipes.DAL;
using TE.AuthLib;
using TE.AuthLib.DAL;

namespace Recipes
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
            // Enable Cookies
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Setup Session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Sets session expiration to 20 minuates
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
            });

            /**** DEPENDENCY INJECTION *****/
            // First, find the connection string in AppSettings.json using the Configuration object
            // TODO 01 (Startup): Get connection strings for Recipe and User in appsettings.json 
            string connectionString = Configuration.GetConnectionString("Recipe");
            string userConnectionString = Configuration.GetConnectionString("User");

            // Setup Dependency Injection for DAOs
            services.AddTransient<IUserDAO>(m => new UserSqlDAO(userConnectionString));
            services.AddTransient<IRecipeDAO>(m => new RecipeSqlDAO(connectionString));


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
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Turn on Session
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
