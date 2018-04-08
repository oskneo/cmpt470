using System;
using System.Collections.Generic;
using System.Diagnostics;
// using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using FinalProject.Models.CourseViewModels;
// using FinalProject.Models;
// using FinalProject.Data;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
using Xunit;
// using System.Web.Mvc;
using FinalProject.Controllers;

namespace FinalProject.Tests
{
    public class BaseTest
    {
        [Fact]
        public void TestIndexPage()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }
    }
}
