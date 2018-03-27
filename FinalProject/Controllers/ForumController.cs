using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            
            ViewData["Title"] = "Forum";
            ViewData["Message"] = "Index for CMPT470";
            return View();
        }
        
        public IActionResult NewPost()
        {
            ViewData["Title"] = "Forum";
            ViewData["Message"] = "Submit a new Post";
            return View();
        }
        
        


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
