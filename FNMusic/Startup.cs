using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseLib;
using BaseLib.Models;
using BaseLib.Services;
using BaseLib.Utils;
using FNMusic.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserMgt.Services;
using UserMgt.Services.Impl;

namespace FNMusic
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
            //Configure Cookies
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = new PathString("/login");
                    //options.LogoutPath = new PathString("/logout");
                    //options.AccessDeniedPath = new PathString("/accessdenied");
                    options.ExpireTimeSpan = TimeSpan.FromHours(6);
                });


            //Configure Sessions
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpContextAccessor();

            // Configure BaseLib Application Services
            services.AddTransient<IRestTemplate<ServiceResponse>, RestTemplate<ServiceResponse>>();
            services.AddTransient<IRestTemplate<AccessTokenWithUserDetails>, RestTemplate<AccessTokenWithUserDetails>>();
            services.AddTransient<IRestTemplate<Result<User>>, RestTemplate<Result<User>>>();
            services.AddTransient<IObjectConverter<byte[]>, ByteObjectConverter>();

            services.AddTransient(typeof(UserController));

            services.AddTransient<IAuthService<ServiceResponse>, AuthService>();
            services.AddTransient<IUserService<Result<User>>, UserService>();

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
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc();
        }
    }
}
