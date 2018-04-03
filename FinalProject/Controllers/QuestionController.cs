using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models.QuestionViewModels;
using FinalProject.Models.CourseViewModels;
using FinalProject.Models;
using FinalProject.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace FinalProject.Controllers
{
    public class QuestionController : Controller
    {
        ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        public QuestionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager){
            db=context;
            _userManager=userManager;
        }
        
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        public IActionResult Ask(CourseAndQuestions model,string returnUrl = null){
            
            return View(model);
        }
        [HttpPost]
        public IActionResult toAsk(CourseAndQuestions model,string returnUrl = null){
            var QL=from ql in db.Questions where ql.CourseId == model.CourseId select ql;
            var newmodel=new CourseAndQuestions{
                CourseId=model.CourseId,
                QuestionList=QL.ToList<QuestionModel>()
            };
            
            return PartialView("Ask",newmodel);
        }
        
        [HttpGet]
        public async Task<IActionResult> AskQuestion(string returnUrl = null){
            var us = await GetCurrentUserAsync();
            var data = from sc in db.StudentCourses join s in db.Courses on sc.CourseId equals s.CourseId where sc.ApplicationUser == us select new CourseModel {
                Department = s.Department + s.CourseNumber, 
                CourseId = s.CourseId
            };
            QuestionAndCourse _model=new QuestionAndCourse();
            _model.CourseList=data.ToList<CourseModel>();
            return View(_model);
        }
        [HttpPost]
        public async Task<IActionResult> AskQuestion(QuestionModel model, string returnUrl = null)
        {
            var us = await GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                QuestionModel qt=new QuestionModel{
                    CourseId = model.CourseId, 
                    Time = DateTime.Now,
                    Title = model.Title,
                    Description = model.Description,
                    ApplicationUser = us
                };
                db.Questions.Add(qt);
                db.SaveChanges();
                return RedirectToAction("QuestionPage","Question", new { QId = qt.QId });
            }
            
            return View(model);
            
        }
        
        [HttpGet]
        public async Task<IActionResult> QuestionPage(QuestionAnswer model, string returnUrl = null){
            // QuestionAnswer model=new QuestionAnswer();
            model.Answers=db.Answers.ToList<AnswerModel>();
            var us = await GetCurrentUserAsync();
            model.ApplicationUser=us;

            var fa= from i in db.Questions where i.QId == model.QId select i;
            var fe=fa.ToList<QuestionModel>().FirstOrDefault();
            model.QuestionTitle=fe.Title;
            model.QuestionContent=fe.Description;
            model.Time=fe.Time;

            // var data = from sc in db.StudentCourses join s in db.Courses on sc.CourseId equals s.CourseId where sc.ApplicationUser == us select new CourseModel {
            //     Department = s.Department + s.CourseNumber, 
            //     CourseId = s.CourseId
            // };
            // QuestionAndCourse _model=new QuestionAndCourse();
            // _model.CourseList=data.ToList<CourseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ReplyTo(QuestionAnswer model, string returnUrl = null){
            
            var us = await GetCurrentUserAsync();
            AnswerModel am=new AnswerModel();
            am.RefAId=model.AId;
            am.QId=model.QId;
            am.ApplicationUser=us;
            return View(am);
        }

        [HttpPost]
        public async Task<IActionResult> ReplyTo(AnswerModel model, string returnUrl = null){
            
            var us = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                AnswerModel qt=new AnswerModel{
                    // Reply=model.Reply,
                    // QId = model.QId, 
                    // Time = DateTime.Now,
                    // ApplicationUser = us,
                    // RefAId = model.RefAId
                    Reply=model.Reply,
                    QId = model.QId, 
                    Time = DateTime.Now,
                    ApplicationUser = us,
                    RefAId = model.RefAId
                };
                db.Answers.Add(qt);
                db.SaveChanges();
                return RedirectToAction("QuestionPage","Question", new { QId = qt.QId });
            }



            AnswerModel am=new AnswerModel();
            am.RefAId=model.AnswerId;
            am.QId=model.QId;
            am.ApplicationUser=us;
            return View(am);
        }
        


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
