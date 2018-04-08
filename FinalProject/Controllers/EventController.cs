using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models.EventViewModels;
using FinalProject.Models;
using FinalProject.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ScheduleEmailClass;
using FinalProject.Models.CourseViewModels;


namespace FinalProject.Controllers
{
    public class EventController : Controller
    {
        ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        public EventController(ApplicationDbContext context, UserManager<ApplicationUser> userManager){
            db=context;
            _userManager=userManager;
        }
        
        
        
        [HttpGet]
        public IActionResult AddEvent(string returnUrl = null){
            return View();
        }
        [HttpPost]
        public IActionResult AddEvent(EventModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                
                db.Events.Add(new EventModel{
                    Date = model.Date, 
                    Time = model.Time,
                    Location = model.Location,
                    NumberOfSeats = model.NumberOfSeats,
                    Title = model.Title,
                    Description = model.Description
                });
                db.SaveChanges();
                return RedirectToAction("AddEvent","Event");
            }
            
            return View(model);
            
        }
        
        public IActionResult GroupEvent(GEvent model)
        {
            
            
            return PartialView("GroupEvent",model);
            
        }
        
        
        [HttpPost]
        public IActionResult GroupEvent(GEvent model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var GroupList = (from us in db.Users
                                join sc in db.StudentCourses on us.Id equals sc.ApplicationUser.Id
                                where sc.GroupNumber==model.GroupNumber && sc.CourseId==model.CourseId
                                select us).ToList();
                
                
                EventModel EM=new EventModel{
                    Date = model.Date, 
                    Time = model.Time,
                    Location = model.Location,
                    NumberOfSeats = GroupList.Count,
                    OccupiedSeats = GroupList.Count,
                    Title = model.Title,
                    Description = model.Description
                };
                db.Events.Add(EM);
                
                foreach (var item in GroupList){
                    StudentEvent scs = new StudentEvent();
                    scs.EventId = EM.EventId;
                    scs.ApplicationUser = item;
            
                    db.StudentEvents.Add(scs);
                }
                
            
            
            
            
            
                db.SaveChanges();
                ScheduleEmail send= new ScheduleEmail(db);
                send.getEvent();
                TempData["Message"]="Group created successfully!";
                
            }
            else{
                TempData["Message"]="Group created failed!";
            }
            
            
            return RedirectToAction("ChooseEvent","Event");
            
        }
        
        public IActionResult EventPage(string returnUrl = null){
            
            var model = db.Events.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult ChooseEvent(string returnUrl = null){
            var model = db.Events.ToList();
            // ViewData["Message"]="Duplicate Enrollment!";
            ViewData["Users"]=db.Users.ToList();
            ViewData["SE"]=db.StudentEvents.ToList();
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> myEvent(string returnUrl = null){
            var us = await GetCurrentUserAsync();
            var model = 
                (from e in db.Events
                join se in db.StudentEvents on  e.EventId equals se.EventId
                where se.ApplicationUser == us
                select e).ToList();
            // var model = db.Events.ToList();
            // ViewData["Message"]="Duplicate Enrollment!";
            return View(model);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        
        // [HttpPost]
        public async Task<IActionResult> ChooseEventB(EventModel model){

            // var Event = from crs in db.Events where crs.EventId == model.EventId select crs;
            // EventModel crs = Event[0];
            
            
            var evt=db.Events.SingleOrDefault( e=> e.EventId==model.EventId);
            if(evt.OccupiedSeats>=evt.NumberOfSeats){
                TempData["Message"]="The event is full!";
                // return View();
                return RedirectToAction("ChooseEvent","Event");
            }
            evt.OccupiedSeats+=1;
            
            var us = await GetCurrentUserAsync();
            var check=db.StudentEvents.SingleOrDefault(l=> l.EventId==model.EventId && l.ApplicationUser==us);
            if(check!=null){
                TempData["Message"]="Duplicated Enrollment!";
                // return View("ChooseEvent");
                return RedirectToAction("ChooseEvent","Event");
            }

            

            StudentEvent scs = new StudentEvent();
            scs.EventId = model.EventId;
            scs.ApplicationUser = us;
            
            db.StudentEvents.Add(scs);
            
            
            
            
            db.SaveChanges();
            ScheduleEmail send= new ScheduleEmail(db);
            send.getEvent();


            // return PartialView("part",_model);
            return RedirectToAction("ChooseEvent","Event");
            // return View(db.Events.ToList());
        }
        
        public IActionResult DeleteAllEvents()
        {
            if(ModelState.IsValid){
                foreach(var i in db.Events){
                    db.Events.Remove(i);
                }
                
                db.SaveChanges();
                TempData["Message"]="Delete Succesfully!";
                return RedirectToAction("Manage","Admin");
            }
            
            TempData["Message"]="Delete Failed!";
            return RedirectToAction("Manage","Admin");
            
        }

        public async Task<IActionResult> part(string returnUrl = null){
            var us = await GetCurrentUserAsync();
            var data = from sc in db.StudentEvents join s in db.Events on sc.EventId equals s.EventId where sc.ApplicationUser == us select new EventModel {
                Date = s.Date, 
                Time = s.Time,
                Location = s.Location,
                NumberOfSeats = s.NumberOfSeats,
                Title = s.Title,
                Description = s.Description
            };
            List<EventModel> _model=data.ToList<EventModel>();
            return View(_model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
