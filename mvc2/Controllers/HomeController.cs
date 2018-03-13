using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using mvc2.Models.HomeViewModels;
using mvc2.Models;
using mvc2.Data;

namespace mvc2.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController(ApplicationDbContext context){
            db=context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        
        [HttpGet]
        public IActionResult Add(string returnUrl = null){
            return View();
        }
        [HttpPost]
        public IActionResult Add(DataModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                //var db = new ApplicationDbContext(); 
                db.emp.Add(new DataModel{
                    Id = model.Id, 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age
                });
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            
            return View(model);
            
        }
        
        public IActionResult Show(string returnUrl = null){
            
            //ViewData["Data"
            var model = db.emp.ToList();
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
