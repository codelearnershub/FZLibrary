using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LibaryManagementSystem2.Models;
using LibaryManagementSystem2.Interfaces;
using LibaryManagementSystem2.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using LibaryManagementSystem2.Services;
namespace LibaryManagementSystem2
{
    public class Startup 
    {
           public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<LibaryManagementDBContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("LibaryManagementDBContext")));
            //   services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
            // {
            //     config.LoginPath = "/Libary/Login";
            //     config.LogoutPath = "/Libary/Logout";
            //     config.Cookie.Name = "LibaryAuth";
            // });
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IFineService, FineService>();
            services.AddScoped<IFineRepository, FineRepository>();
            services.AddScoped<ILendingRepository, LendingRepository>();
             services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRackService, RackService>();
            services.AddScoped<IRackRepository, RackRepository>();
            services.AddScoped<IBookItemRepository, BooksItemRepository>();
            services.AddScoped<IBookItemService, BookItemService>();
            services.AddScoped<ILendingService, LendingService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILendingRepository, LendingRepository>();
            services.AddScoped<ILendingService, LendingService>();
            services.AddScoped<IFineRepository, FineRepository>();
            services.AddScoped<IFineService, FineService>();
            services.AddScoped<IRackRepository, RackRepository>();
            services.AddScoped<IBookItemService, BookItemService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
             services.AddScoped<IUserRoleRepository, UserRoleRepository>();
              services.AddScoped<IUserRoleService, UserRoleService>();
               

        
             
          


          
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
            app.UseAuthentication();
        
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                      });


        }           
       
    }     
}
