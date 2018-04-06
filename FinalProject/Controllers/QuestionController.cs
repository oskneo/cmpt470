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
            QuestionAnswer _model=new QuestionAnswer();
            QuestionModel qt;
            if (ModelState.IsValid)
            {
                qt=new QuestionModel{
                    CourseId = model.CourseId, 
                    Time = DateTime.Now,
                    Title = model.Title,
                    Description = model.Description,
                    ApplicationUser = us,
                    UserName=us.UserName
                };
                db.Questions.Add(qt);
                db.SaveChanges();
                _model.Time=qt.Time;
                _model.QId=qt.QId;
                
            }
            //return RedirectToAction("QuestionPage","Question", new { QId = qt.QId });
            
            //return View(model);
            

            _model.Answers=db.Answers.ToList<AnswerModel>();
            _model.UserName=us.UserName;
            

            _model.QuestionTitle=model.Title;
            _model.QuestionContent=model.Description;
            
            return PartialView("QuestionPage",_model);
            
        }
        
        [HttpGet]
        public IActionResult QuestionPage(QuestionAnswer model, string returnUrl = null){
            // QuestionAnswer model=new QuestionAnswer();
            
            
            
            
            // model.Answers=db.Answers.ToList<AnswerModel>();
            // var us = await GetCurrentUserAsync();
            // model.ApplicationUser=us;

            // var fa= from i in db.Questions where i.QId == model.QId select i;
            // var fe=fa.ToList<QuestionModel>().FirstOrDefault();
            // model.QuestionTitle=fe.Title;
            // model.QuestionContent=fe.Description;
            // model.Time=fe.Time;





            // var data = from sc in db.StudentCourses join s in db.Courses on sc.CourseId equals s.CourseId where sc.ApplicationUser == us select new CourseModel {
            //     Department = s.Department + s.CourseNumber, 
            //     CourseId = s.CourseId
            // };
            // QuestionAndCourse _model=new QuestionAndCourse();
            // _model.CourseList=data.ToList<CourseModel>();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult toQuestionPage(QuestionAnswer model, string returnUrl = null){
            
            model.Answers=db.Answers.ToList<AnswerModel>();
            // var us = await GetCurrentUserAsync();
            // model.ApplicationUser=us;

            var fa= from i in db.Questions where i.QId == model.QId select i;
            var fe=fa.ToList<QuestionModel>().FirstOrDefault();
            model.QuestionTitle=fe.Title;
            model.QuestionContent=fe.Description;
            model.Time=fe.Time;
            return PartialView("QuestionPage",model);
        }
        
        
        [HttpPost]
        public IActionResult toReplyTo(QuestionAnswer model, string returnUrl = null){
            
            // var us = await GetCurrentUserAsync();
            AnswerModel am=new AnswerModel();
            am.RefAId=model.AId;
            am.QId=model.QId;
            // am.UserName=Model.UserName;
            return PartialView("ReplyTo",am);
        }

        [HttpGet]
        public IActionResult ReplyTo(AnswerModel model, string returnUrl = null){
            
            // var us = await GetCurrentUserAsync();
            // AnswerModel am=new AnswerModel();
            // am.RefAId=model.AId;
            // am.QId=model.QId;
            // am.ApplicationUser=us;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ReplyToQ(AnswerModel model, string returnUrl = null){
            
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
                    UserName = us.UserName,
                    RefAId = model.RefAId
                };
                db.Answers.Add(qt);
                db.SaveChanges();
                //return RedirectToAction("QuestionPage","Question", new { QId = qt.QId });
            }
            
            
            
            
            QuestionAnswer _model=new QuestionAnswer();
            
            _model.Answers=db.Answers.ToList<AnswerModel>();
            _model.UserName=us.UserName;
            _model.QId=model.QId;

            var fa= from i in db.Questions where i.QId == model.QId select i;
            var fe=fa.ToList<QuestionModel>().FirstOrDefault();
            _model.QuestionTitle=fe.Title;
            _model.QuestionContent=fe.Description;
            //_model.Time=fe.Time;
            return PartialView("QuestionPage",_model);



            // AnswerModel am=new AnswerModel();
            // am.RefAId=model.AnswerId;
            // am.QId=model.QId;
            // am.ApplicationUser=us;
            // return (am);
        }
        


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
