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
    public class CourseP
    {
        

        // public virtual ApplicationUser ApplicationUser { get; set; }
        
        public uint CourseId { get; set; }
        public uint PId { get; set; }
        public CourseP(){
            PId=0;
        }

        
        
    }
    
    // public class StudentCourseDBContext : DbContext
    // {
        
    // }
    
}
