using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using mvc2.Models;
using mvc2.Services;

namespace mvc2.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _roleManager = roleManager;
            
            
            
        }

        [TempData]
        public string ErrorMessage { get; set; }

        
        [HttpGet]
        public IActionResult Admin(string returnUrl=null)
        {
            //var role = System.Web.Security.Roles.GetRolesForUser().Single();
            
            
            
            if(User.IsInRole("Admin")){
                ViewData["Message"] = "You are an Admin.";
            }
            else{
                return RedirectToAction("Index","Home");
            }
            
            
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            // if (Url.IsLocalUrl(returnUrl))
            // {
            //     return Redirect(returnUrl);
            // }
            // else
            // {
            //     return RedirectToAction(nameof(HomeController.Index), "Home");
            // }
            return View();
        }

    }
}
