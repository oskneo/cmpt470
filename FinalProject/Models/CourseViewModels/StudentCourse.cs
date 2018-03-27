using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models.CourseViewModels
{
    public class StudentCourse
    {
        [Key]
        [ForeignKey("Courses")]
        public uint CourseID { get; set; }
        
        [Key, ForeignKey("ApplicationUser")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
    
    public class StudentCourseDBContext : DbContext
    {
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
    
}
