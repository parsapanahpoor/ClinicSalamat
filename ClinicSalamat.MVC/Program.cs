using ClinicSalamat.Infrastructure.EfCore.ApplicationDbContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using ClinicSalamat.Application;
using Microsoft.EntityFrameworkCore;
using ClinicSalamat.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Hosting;

namespace ClinicSalamat.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        #region Services

        var builder = WebApplication.CreateBuilder(args);

        #region Register Services In IoC Layer

        DependencyContainer.ConfigureDependencies(builder.Services);

        #endregion

        #region MVC

        builder.Services.AddControllers();
        {
            builder.Services.RegisterApplicationServices();
        }

        builder.Services.AddControllersWithViews();

        #endregion

        #region Add DBContext

        builder.Services.AddDbContext<ClinicSalamatDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicSalamatDbContextConnection"));
        });

        #endregion

        #region Authentication

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
            // Add Cookie settings
            .AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

        #endregion

        #endregion

        #region Middlewares

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
      name: "area",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

        #endregion
    }
}
