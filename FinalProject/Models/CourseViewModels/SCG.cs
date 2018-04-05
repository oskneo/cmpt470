using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Models.CourseViewModels
{
    public class SCG
    {
        

        // public virtual ApplicationUser ApplicationUser { get; set; }
        
        public string uid { get; set;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string StudentId { get; set; }
        public uint GroupNumber { get; set; }

        
        
    }
    
    // public class StudentCourseDBContext : DbContext
    // {
        
    // }
    
}
