using BlazorHRM.Data;
using BlazorHRM.Models;
using BlazorHRM.Repositories;
using BlazorHRM.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Syncfusion.Blazor;

namespace BlazorHRM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            #region Repos
            builder.Services.AddScoped<CityRepository>();
            builder.Services.AddScoped<LoginRepository>();
            builder.Services.AddScoped<EmpRepository>();
            builder.Services.AddScoped<AdminRepository>();
            builder.Services.AddScoped<DepRepository>();
            builder.Services.AddScoped<EmpLoginRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<CityService>();
            builder.Services.AddScoped<GlobalService>();
            builder.Services.AddScoped<LoginService>();
            builder.Services.AddScoped<EmpService>();
            builder.Services.AddScoped<TaskService>();
            builder.Services.AddScoped<DepService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}