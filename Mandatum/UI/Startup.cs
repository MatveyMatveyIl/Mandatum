using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Application.ApiInterface;
using Mandatum.Controllers;
using Mandatum.Convertors;
using Mandatum.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
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
            // >> db connect 
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("UI")));
            // << db connect 
            // >> api
            services.AddScoped<IBoardApi, BoardApi>();
            services.AddScoped<ITaskApi, TaskApi>();
            services.AddScoped<IUserApi, UserApi>();
            // << api
            // >> repo
            services.AddScoped<ITaskRepo, TaskRepo>();
            services.AddScoped<IBoardRepo, BoardRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            // << repo
            // >> convertors
            services.AddScoped<UserConverterModel>();
            services.AddScoped<UserConverterRegister>();
            services.AddScoped<TaskModelConverter>();
            services.AddScoped<BoardModelConverter>();
            // << convertors
            // установка конфигурации подключения

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");
                    options.ClientId = "137321901177-9lsr1i1no0cui21t65pbej3jldqcb2cs.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                });
            services.AddIdentity<UserRecord, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
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