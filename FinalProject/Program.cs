using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FinalProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);



            // using (var scope = host.ApplicationServices.CreateScope())
            // {
                // var db = serviceScope.ServiceProvider.GetRequiredService<WebMarksDbContext>();
                // var _rolemanager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                
                // if(!await _rolemanager.RoleExistsAsync("Admin")){
                //     await _rolemanager.CreateAsync(new IdentityRole("Admin"));
                // }
                // if(!await _rolemanager.RoleExistsAsync("Student")){
                //     await _rolemanager.CreateAsync(new IdentityRole("Student"));
                // }
            // }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
