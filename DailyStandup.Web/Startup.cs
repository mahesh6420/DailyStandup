using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DailyStandup.Web.Data;
using DailyStandup.Web.Models;
using DailyStandup.Entities.Models.User;
using DailyStandup.Infrastructure.Interfaces;
using DailyStandup.Infrastructure.Services;
using DailyStandup.Infrastructure.Interfaces.IServices;
using DailyStandup.Infrastructure.Repository;
using DailyStandup.Infrastructure.Interfaces.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DailyStandup.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/user/account/login");
                });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IStandupService, StandupService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "AdminRoute",
                    template: "{area=user}/{controller=Dashboard}/{action=Index}");

                routes.MapRoute(
                    name: "LoginRoute",
                    template: "{area=user}/{controller=Account}/{action=Login}");

                //routes.MapRoute(
                //    name: "default",
                //    template: "{area:exists}/{controller=Account}/{action=Login}/{id?}");

            });
        }
    }
}
