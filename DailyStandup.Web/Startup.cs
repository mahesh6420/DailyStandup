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
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

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

            IdentityBuilder builder = services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(ApplicationRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>()
              .AddRoleValidator<RoleValidator<ApplicationRole>>()
              .AddRoleManager<RoleManager<ApplicationRole>>()
              .AddSignInManager<SignInManager<ApplicationUser>>()
              .AddDefaultTokenProviders();

          
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            //    options =>
            //    {
            //        options.LoginPath = new PathString("/user/account/login");
            //        options.AccessDeniedPath = new PathString("/user/account/accessdenied");
            //    });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IWorkService, WorkService>();
            services.AddTransient<IObstacleService, ObstacleService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
              options =>
              {
                  options.LoginPath = new PathString("/user/account/login");
                  options.AccessDeniedPath = new PathString("/user/account/accessdenied");
              });
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
