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
                ViewData["Message"]="Added!";
                return View();
            }
            
            return View(model);
            
        }
        
        public IActionResult CourseList(string returnUrl = null){
            
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

        public async Task<IActionResult> Enroll(CourseModel model, string returnUrl = null){

            // var course = from crs in db.Courses where crs.CourseId == model.CourseId select crs;
            // CourseModel crs = course[0];
            
            var us = await GetCurrentUserAsync();
            var check=db.StudentCourses.SingleOrDefault(l=> l.CourseId==model.CourseId && l.ApplicationUser==us);
            if(check!=null){
                ViewData["Message"]="Duplicate Enrollment!";
                return RedirectToAction("CourseList","Course");
            }

            

            StudentCourse scs = new StudentCourse{
                CourseId = model.CourseId,
                ApplicationUser = us,
                GroupNumber = 0
            };
            db.StudentCourses.Add(scs);
            db.SaveChanges();

            var data = 
                from sc in db.StudentCourses 
                join s in db.Courses on sc.CourseId equals s.CourseId 
                where sc.ApplicationUser == us 
                select new CourseModel {
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
            return RedirectToAction("myCourses","Course");
        }

        public async Task<IActionResult> myCourses(string returnUrl = null){
            var us = await GetCurrentUserAsync();
            var data = 
                from sc in db.StudentCourses 
                join s in db.Courses on sc.CourseId equals s.CourseId 
                where sc.ApplicationUser == us 
                select new CourseModel {
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
        
        public IActionResult CoursePage(CourseP model,string returnUrl = null){
            CourseModel _model= new CourseModel{
                CourseId=model.CourseId
            };
            ViewData["CourseId"]=model.CourseId;
            ViewData["PId"]=model.PId;
            
            return View(_model);
        }
        
        public IActionResult courseInfo(CourseModel model,string returnUrl = null){
            // var newmodel= from sc in db.Courses where sc.CourseId == model.CourseId select sc;
            // var crs=newmodel.ToList<CourseModel>().SingleOrDefault();
            
            return View(model);
        }
        
        public IActionResult toCourseInfo(CourseModel model,string returnUrl = null){
            var newmodel= 
                from sc in db.Courses 
                where sc.CourseId == model.CourseId 
                select sc;
            var crs=newmodel.ToList<CourseModel>().SingleOrDefault();
            
            return PartialView("courseInfo",crs);
        }

        public IActionResult Group(GroupModel model,string returnUrl = null){
            
            
            
            
            return View(model);
        }
        public async Task media(GroupModel model, GroupModel nnl){
            var mus = await GetCurrentUserAsync();
            var mymodel = 
                from sc in db.StudentCourses 
                where sc.CourseId == model.CourseId && sc.ApplicationUser == mus 
                select sc;
            var ap = mymodel.FirstOrDefault();

                      
            
            
            uint gn=0;
            if (ap!=null&&ap.GroupNumber!=0){
                gn=ap.GroupNumber;
            } 

            var gm=
                from us in db.Users 
                join sc in db.StudentCourses on us.Id equals sc.ApplicationUser.Id
                where sc.CourseId == model.CourseId && sc.GroupNumber == gn && sc.GroupNumber != 0
                select new SCG {
                    uid=us.Id,
                    Email=us.Email,
                    StudentId=us.StudentId,
                    UserName=us.UserName
                };


            var scmodel = 
                from us in db.Users 
                join sc in db.StudentCourses on us.Id equals sc.ApplicationUser.Id
                where sc.CourseId == model.CourseId 
                select new SCG {
                    uid=us.Id,
                    Email=us.Email,
                    StudentId=us.StudentId,
                    UserName=us.UserName,
                    GroupNumber=sc.GroupNumber
                };
            
            var scs=scmodel.ToList();



            nnl.CourseId=model.CourseId;
            nnl.StudentCourses=scs;
            nnl.GroupNumber=gn;
            nnl.GroupMembers=gm.ToList();
            

        }

        [HttpPost]
        public async Task<IActionResult> toGroup(GroupModel model){
            GroupModel nl=new GroupModel();

            await media(model,nl);
            
            
            
            
            
            return PartialView("Group",nl);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGroup(GroupModel model){
            
            if (ModelState.IsValid)
            {
                var mus = await GetCurrentUserAsync();
                var newmodel = 
                    from sc in db.StudentCourses 
                    where sc.CourseId == model.CourseId 
                    select sc;
                var max=newmodel.OrderByDescending(i=>i.GroupNumber).FirstOrDefault();
                var mymodel = 
                    from sc in newmodel 
                    where sc.ApplicationUser == mus 
                    select sc;
                var me=mymodel.FirstOrDefault();
                me.GroupNumber = max.GroupNumber + 1;
                db.SaveChanges();
            }
            GroupModel nl=new GroupModel();

            await media(model,nl);




            


            return PartialView("Group",nl);
        }
        [HttpPost]
        public async Task<IActionResult> AddToGroup(GroupModel model){
            
            if (ModelState.IsValid)
            {
                var newmodel = 
                    from sc in db.StudentCourses 
                    where sc.CourseId == model.CourseId && model.userid == sc.ApplicationUser.Id
                    select sc;
                var max=newmodel.FirstOrDefault();
                max.GroupNumber = model.GroupNumber;
                db.SaveChanges();
            }
            GroupModel nl=new GroupModel();

            await media(model,nl);




            


            return PartialView("Group",nl);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
