using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FluentScheduler;
using SendGrid;
using SendGrid.Helpers.Mail;
using FinalProject.Models;
using FinalProject.Models.EventViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;



namespace ScheduleEmailClass
{
    public class ScheduleEmail  
    {      

        public static string EmailAddressFrom { get; set; }
        ApplicationDbContext db;
        static string apiKey;
        Registry registry;

        public ScheduleEmail(ApplicationDbContext ct){

            EmailAddressFrom="Envision@sfu.ca";
            db=ct;
            apiKey = "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";
            // SendEm().Wait();
            registry = new Registry();
            JobManager.Initialize(registry);
            // getEvent();


        }

        static async Task SendEm(string subject,string plainTextContent,string htmlContent,string UserName,string Email)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(EmailAddressFrom, "Envision");
            // var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(Email, UserName);
            // var plainTextContent = "and easy to do anywhere, even with C#";
            // var htmlContent = "<strong>" + plainTextContent + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            
            Console.WriteLine(htmlContent);
        }

        public void getEvent(){
            JobManager.RemoveAllJobs();
            var stevents = 
                (from i in db.StudentEvents
                join e in db.Events on i.EventId equals e.EventId
                join u in db.Users on  i.ApplicationUser.Id equals u.Id
                select new GetEvents {
                    UserName=u.UserName,
                    Title=e.Title,
                    Description=e.Description,
                    Time=e.Date.Date+e.Time.TimeOfDay,
                    Location=e.Location,
                    Email=u.Email
                }).ToList();


            foreach (var item in stevents.ToList()){
                var title="Event reminder to " + item.UserName + "!";
                var content="You will have an event " + item.Title + " take place at " + item.Location + ".\n";
                content+="The event will be at " + item.Time.ToString("yyyy-MM-dd HH:mm:ss") + ".\n";
                content+="Event Description:" + item.Description +".\n";
                var html="<strong>" + content + "</strong>";
                // SendEm(title,content,html,item.UserName,item.Email).Wait();
                JobManager.AddJob(() => SendEm(title,content,html,item.UserName,item.Email).Wait(), s => s
                  .ToRunOnceAt(item.Time.AddHours(-1)));

            }

            
        }

        
        // private async Task Schedule(){
        //     // var registry = new Registry();
        //     // JobManager.Initialize(registry);

        //     // JobManager.AddJob(() => MyEmailService.SendEmail(), s => s
        //     //       .ToRunEvery(1)
        //     //       .Minutes());
            
        //     JobManager.AddJob(() => Console.WriteLine("aaaaa\n"), s => s
        //           .ToRunEvery(10)
        //           .Seconds());
        // }
    }
}