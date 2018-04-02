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
using mvc2.Data;
using mvc2.Models;
using mvc2.Services;

namespace mvc2
{
    public class Startup
    {
    	public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }

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
            
            // var serviceProvider = services.BuildServiceProvider();
            // var rolemanager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // if ( !rolemanager.RoleExists("Admin"))
            // {
            // //   rolemanager.Create(new IdentityRole("Admin"));
            //     var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();   
            //     role.Name = "Admin";   
            //     rolemanager.Create(role);   
   
            // }
            // if ( !await rolemanager.RoleExistsAsync("Member"))
            // {
            //   await rolemanager.CreateAsync(new IdentityRole("Member"));
            // }
            
        }
        
        
        private void createrole(){  
            
            //ApplicationDbContext context = new ApplicationDbContext();   
   
            // var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));   
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));   
   
        } 
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            
            //createrole();
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
