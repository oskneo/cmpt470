using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models.CourseViewModels;
using FinalProject.Models;
using FinalProject.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Xunit;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FinalProject.Controllers;
using Microsoft.AspNetCore.Builder;
// using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Web;
using Moq;
using FinalProject.Models.EventViewModels;

namespace FinalProject.Tests
{
    public class ControllerTest
    {
        
        public ControllerTest()
        {
            Init();
        }
 
        private ApplicationDbContext db;
 
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase();
            var context = new ApplicationDbContext(builder.Options);
            
            db = context;
            
            var course = new CourseModel{
                    Semester = "fall", 
                    Year = 2018,
                    Department = "cmpt",
                    CourseNumber = "470",
                    Instructor = "Lisa",
                    Description = "Web",
                    Session = "d100"
            };
            var courses = Enumerable.Range(1, 10)
            .Select(i => course);
            db.Courses.AddRange(courses);
            db.SaveChanges();
        }
        
        [Fact]
        public void TestCourseList(){
            
            // var roleStore = new RoleStore<IdentityRole>(db);
            // var roleManager = new RoleManager<IdentityRole>(roleStore,null,null,null,null);
            var controller=new CourseController(db,null);
            var result = controller.CourseList() ;
            
            // // var result = await controller.Index();
 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<CourseModel>>(viewResult.ViewData.Model);
            var model2 = Assert.IsType<List<CourseModel>>(viewResult.ViewData.Model);
            Assert.Equal("cmpt", model2[0].Department);
            
            
            
            
            
        }
        
        
        
        
        
        [Fact]
        public void TestAddEvent(){
            var Event = new EventModel{
                    Location = "Burnaby", 
                    Date = DateTime.Now,
                    Time = DateTime.Now,
                    Title = "My event",
                    Description = "event",
                    NumberOfSeats = 10
            };
            
            
            
            
            var controller=new EventController(db,null);
            var result = controller.AddEvent(Event,null);
 
            var viewResult = Assert.IsType<ViewResult>(result);
            // var model = Assert.IsAssignableFrom<List<CourseModel>>(viewResult.ViewData.Model);
            Assert.Equal("Burnaby", db.Events.FirstOrDefault().Location);
            // var mockService = new Mock<ApplicationDbContext>();
            
            // var controller=new CourseController(mockService.Object,null);
            
            
            
            
        }
        
        [Fact]
        public void TestChooseEvent(){
            var Event = new EventModel{
                    Location = "Burnaby", 
                    Date = DateTime.Now,
                    Time = DateTime.Now,
                    Title = "My event",
                    Description = "event",
                    NumberOfSeats = 10
            };
            var controller=new EventController(db,null);
            controller.AddEvent(Event,null);
            var result = controller.ChooseEvent();
 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<EventModel>>(viewResult.ViewData.Model);
            var model2 = Assert.IsType<List<EventModel>>(viewResult.ViewData.Model);
            // Assert.Equal("Burnaby", db.Events.SingleOrDefault().Location);
            // var mockService = new Mock<ApplicationDbContext>();
            Assert.Equal("My event", model2[0].Title);
            // var controller=new CourseController(mockService.Object,null);
            
            
            
            
        }

    }
}
