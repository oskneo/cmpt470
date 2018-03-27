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
    public class StudentCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint StudentCourseId { get; set; }

        [ForeignKey("Courses")]
        public uint CourseId { get; set; }

        public virtual CourseModel Courses { get; set; }
        
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        
        
    }
    
    // public class StudentCourseDBContext : DbContext
    // {
        
    // }
    
}
