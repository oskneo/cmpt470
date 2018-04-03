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
    public class GroupModel
    {
        

        public uint CourseId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        // public virtual List<ApplicationUser> ApplicationUsers { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

        public uint GroupNumber { get; set; }

        
        
    }
    
    // public class StudentCourseDBContext : DbContext
    // {
        
    // }
    
}
