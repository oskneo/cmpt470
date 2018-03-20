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
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Services;
using ExploreCalifornia;

namespace FinalProject
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
                options.UseMySql(Configuration.GetConnectionString("MySQLConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            services.AddSignalR();
            
            
        }
        
        
        
        private async Task createrole(IApplicationBuilder app){
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var db = services.GetService<ApplicationDbContext>();
                if(db.Database.GetPendingMigrations().Any()){
                    await db.Database.MigrateAsync();
                    var _rolemanager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                
                    if(!await _rolemanager.RoleExistsAsync("Admin")){
                        await _rolemanager.CreateAsync(new IdentityRole("Admin"));
                    }
                    if(!await _rolemanager.RoleExistsAsync("Student")){
                        await _rolemanager.CreateAsync(new IdentityRole("Student"));
                    }
                }
                // var _rolemanager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                
                // if(!await _rolemanager.RoleExistsAsync("Admin")){
                //     await _rolemanager.CreateAsync(new IdentityRole("Admin"));
                // }
                // if(!await _rolemanager.RoleExistsAsync("Student")){
                //     await _rolemanager.CreateAsync(new IdentityRole("Student"));
                // }
            }
            
            
            
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
            app.UseWebSockets();
            
            app.UseSignalR(routes =>
            {
                routes.MapHub<LiveHelpHub>("lhh/livehelphub");
            });
            createrole(app).Wait();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
