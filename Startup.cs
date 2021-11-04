using FavoriteMaster.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FavoriteMaster
{
    public class Startup
    {
      //  public static readonly string Id_DB = "Weather";
        public static readonly string Id_DB = "FavoriteMaster";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
              //  CreateDbIfNot();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may
                //want to change this for production scenarios
                //, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapGet("/userend", async context =>
                {
                  
                    await context.Response.WriteAsync("Hello Index!");
                });
            });



            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
/*
        public void CreateDbIfNot()
        {

            //@"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
          //  string StringConect = @"Data Source=LAPTOP-046QU23H\SQLEXPRESS;Integrated Security=True;";
            string StringConect = @"Data Source=.\SQLEXPRESS;Integrated Security=True;";

            SqlConnection Connect = new SqlConnection(StringConect);
            Connect.Open();
            //подготовить запрос insert
            //в переменной типа string
            //CREATE DATABASE IF NOT EXISTS {Id_DB};
            // string Id_DB = "Weather";
            string insertString = $"If(db_id(N'{Id_DB}') IS NULL) CREATE DATABASE[{Id_DB}]";


            //создать объект command,
            //инициализировав оба свойства
            //"If(db_id(N'Weather') IS NULL) CREATE DATABASE[Weather]"
            SqlCommand cmd = new SqlCommand(insertString, Connect);
            //выполнить запрос, занесенный
            //в объект command

            cmd.ExecuteNonQuery();
            Connect.Close();
        }
*/
    }


}
