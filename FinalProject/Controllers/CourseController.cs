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


namespace FinalProject.Controllers
{
    public class CourseController : Controller
    {
        ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        public CourseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager){
            db=context;
            _userManager=userManager;
        }
        
        
        
        [HttpGet]
        public IActionResult AddCourse(string returnUrl = null){
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(CourseModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                
                db.Courses.Add(new CourseModel{
                    Semester = model.Semester, 
                    Year = model.Year,
                    Department = model.Department,
                    CourseNumber = model.CourseNumber,
                    Instructor = model.Instructor,
                    Description = model.Description,
                    Session = model.Session
                });
                db.SaveChanges();
                return RedirectToAction("AddCourse","Course");
            }
            
            return View(model);
            
        }
        
        public IActionResult CoursePage(string returnUrl = null){
            
            var model = db.Courses.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult EnrollCourse(string returnUrl = null){
            var model = db.Courses.ToList();
            // ViewData["Message"]="Duplicate Enrollment!";
            return View(model);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpPost]
        public async Task<IActionResult> EnrollCourse(CourseModel model, string returnUrl = null){

            // var course = from crs in db.Courses where crs.CourseId == model.CourseId select crs;
            // CourseModel crs = course[0];
            
            var us = await GetCurrentUserAsync();
            var check=db.StudentCourses.SingleOrDefault(l=> l.CourseId==model.CourseId && l.ApplicationUser==us);
            if(check!=null){
                ViewData["Message"]="Duplicate Enrollment!";
                return View();
            }

            

            StudentCourse scs = new StudentCourse{
                CourseId = model.CourseId,
                ApplicationUser = us
            };
            db.StudentCourses.Add(scs);
            db.SaveChanges();

            var data = from sc in db.StudentCourses join s in db.Courses on sc.CourseId equals s.CourseId where sc.ApplicationUser == us select new CourseModel {
                CourseId=s.CourseId,
                Year=s.Year,
                Semester=s.Semester,
                Department=s.Department,
                CourseNumber=s.CourseNumber,
                Session=s.Session,
                Instructor=s.Instructor,
                Description=s.Description
            };
            List<CourseModel> _model=data.ToList<CourseModel>();

            // return PartialView("part",_model);
            return RedirectToAction("part","Course");
        }

        public async Task<IActionResult> part(string returnUrl = null){
            var us = await GetCurrentUserAsync();
            var data = from sc in db.StudentCourses join s in db.Courses on sc.CourseId equals s.CourseId where sc.ApplicationUser == us select new CourseModel {
                CourseId=s.CourseId,
                Year=s.Year,
                Semester=s.Semester,
                Department=s.Department,
                CourseNumber=s.CourseNumber,
                Session=s.Session,
                Instructor=s.Instructor,
                Description=s.Description
            };
            List<CourseModel> _model=data.ToList<CourseModel>();
            return View(_model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
