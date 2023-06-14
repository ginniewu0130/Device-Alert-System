using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJ_Login.Data;
using Microsoft.AspNetCore.Http;

namespace PJ_Login
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
            services.AddControllersWithViews();
            //加入Cookie驗證, 同時設定選項
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {                 
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    //登入路徑
                    options.LoginPath = new PathString("/Login/LoginPage");
                    //登出路徑
                    options.LogoutPath = new PathString("/Login/Logout");
                    //拒絕存取路徑
                    options.AccessDeniedPath = new PathString("/Login/AccessDenied");
                });
            services.AddDbContext<LoginContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LoginContext"));
            });
            services.AddDbContext<ChartDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ChartDBContext"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            //Cookie驗證所需Middleware
            app.UseAuthentication(); //驗證

            app.UseAuthorization();  //授權

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=LoginPage}/{id?}");
                
            });
        }
    }
}
