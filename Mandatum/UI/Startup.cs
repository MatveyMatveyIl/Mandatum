using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Mandatum.Controllers;
using Mandatum.Convertors;
using Mandatum.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mandatum
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
 
        public IConfiguration Configuration { get; }
 
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddSingleton<TaskRecord>();
            services.AddSingleton<BoardRecord>();
            services.AddSingleton<UserRecord>();*/
            //services.AddScoped<IUserRepo, UserRepo>();
            //services.AddSingleton<UserConvertor>();
            /*services.AddSingleton<BoardApi>();
            services.AddSingleton<BoardRepo>();*/
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Context>(options => options.UseSqlServer(connection));
            /*services.AddScoped<BoardApi>();
            services.AddScoped<BoardRepo>();
            services.AddScoped<UserApi>();
            services.AddScoped<UserRepo>();
            services.AddScoped<UserConvertorModel>();
            services.AddScoped<UserConvertorRegister>();
            services.AddScoped<TaskRepo>();
            services.AddScoped<TaskApi>();
            services.AddScoped<TaskModelConverter>();*/
            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddControllersWithViews();
        }
 
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
 
            app.UseStaticFiles();
 
            app.UseRouting();
 
            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация
 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}