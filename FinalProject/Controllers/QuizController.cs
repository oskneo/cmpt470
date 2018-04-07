using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models.QuizViewModels;
using FinalProject.Models;
using FinalProject.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ScheduleEmailClass;
using FinalProject.Models.CourseViewModels;


namespace FinalProject.Controllers
{
    public class QuizController : Controller
    {
        ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        public QuizController(ApplicationDbContext context, UserManager<ApplicationUser> userManager){
            db=context;
            _userManager=userManager;
        }
        
        // [HttpPost]
        [HttpGet]
        public IActionResult AddQuiz( string returnUrl = null)
        {
            var data = from s in db.Courses select new CourseModel {
                Department = s.Department + s.CourseNumber + " " + s.Session, 
                CourseId = s.CourseId
            };
            ViewData["quiz"]=data.ToList();
            
            return View();
            
        }

        [HttpPost]
        public IActionResult AddQuiz(QuizModel model, string returnUrl = null)
        {
            if (ModelState.IsValid){
                db.Quizs.Add(model);
                db.SaveChanges();
                QuizQuestion _model= new QuizQuestion{
                    QuizId=model.QuizId,
                    Index=1,
                    Finished=false
                };
                return RedirectToAction("AddQuizQuestion","Quiz",_model);
            }
            
            
            return RedirectToAction("AddQuiz","Quiz");
            
        }

        [HttpGet]
        public IActionResult AddQuizQuestion(QuizQuestion model)
        {
            
            
            
            return View(model);
            
        }
        
        [HttpPost]
        public IActionResult FinishAddingQ(QuizQuestion model){
            return AddQuizQuestion(model,"");
        }

        [HttpPost]
        public IActionResult AddQuizQuestion(QuizQuestion model, string returnUrl = null)
        {
            if (ModelState.IsValid ){
                Console.WriteLine("QuizId:"+model.QuizId+"\n");
                Console.WriteLine("QuizQuestionId:"+model.QuizQuestionId+"\n");
                Console.WriteLine("Index:"+model.Index+"\n");
                Console.WriteLine("QuiQuestionzId:"+model.Question+"\n");
                Console.WriteLine("CorrectAnswer:"+model.CorrectAnswer+"\n");
                Console.WriteLine("AnswerA:"+model.AnswerA+"\n");
                Console.WriteLine("Finished:"+model.Finished+"\n");
                Console.WriteLine("AnswerB:"+model.AnswerB+"\n");
                db.QuizQuestions.Add(model);
                db.SaveChanges();
                model.Index++;
                model.QuizQuestionId=0;
                model.CorrectAnswer=' ';
                model.AnswerA="";
                model.AnswerB="";
                model.AnswerC="";
                model.AnswerD="";
                model.Question="";
                if(model.Finished==false){
                    TempData["Message"]="A quiz question created!";
                    return RedirectToAction("AddQuizQuestion","Quiz",model);
                }
                else{
                    TempData["Message"]="Quiz Created!";
                    return RedirectToAction("AddQuiz","Quiz");
                }
                
            }
            TempData["Message"]="Problem happens!";
            
            return RedirectToAction("AddQuiz","Quiz");
            
        }
        //toQuizList
        public IActionResult toQuizs(CourseModel model)
        {
            
            var QL= 
                (from q in db.Quizs
                where q.CourseId == model.CourseId
                select q).ToList();
            TempData["CourseId"]=model.CourseId;
            TempData["quizs"]=QL;
            
            return PartialView("Quizs");
            
        }

        public IActionResult toTakeQuiz(QuizModel model)
        {
            
            var QQ= 
                (from q in db.Quizs
                join qq in db.QuizQuestions on  q.QuizId equals qq.QuizId
                where qq.QuizId == model.QuizId
                select qq).ToList();
            TempData["CourseId"]=model.CourseId;
            TempData["qid"]=model.QuizId;
            TempData["title"]=model.Title;
            TempData["Description"]=model.Description;
            
            return PartialView("TakeQuiz",QQ);
            
        }
        
        public IActionResult DeleteAllQuizzes()
        {
            if(ModelState.IsValid){
                foreach(var i in db.QuizQuestions){
                    db.QuizQuestions.Remove(i);
                }
                foreach(var q in db.Quizs){
                    db.Quizs.Remove(q);
                }
                db.SaveChanges();
                TempData["Message"]="Delete Succesfully!";
                return RedirectToAction("Manage","Admin");
            }
            
            TempData["Message"]="Delete Failed!";
            return RedirectToAction("Manage","Admin");
            
        }

        [HttpPost]
        public IActionResult TakeQuiz(List<QuizQuestion> model, string returnUrl = null)
        {
            // var quizId=model[0]
            
            var QQ= 
                (from q in db.Quizs
                join qq in db.QuizQuestions on q.QuizId equals qq.QuizId
                where qq.QuizId == model[0].QuizId
                select qq).ToList();
            int i=0;
            int mark=0;
            // TempData["Message"]="msg:"+model[0].QuizId+" ";
            for(;i<QQ.Count;i++){
                if(QQ[i].CorrectAnswer==model[i].CorrectAnswer){
                    mark++;
                }
                // TempData["Message"]+="QQ="+QQ[i].CorrectAnswer+"<br>model="+model[i].CorrectAnswer+"<br>";
            }
            
            // TempData["CourseId"]=model.CourseId;
            // TempData["qm"]=model;
            TempData["mark"]=mark;
            
            
            TempData["total"]=i;
            
            return PartialView("QuizResult",new QuizModel{});
            
        }
        


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
