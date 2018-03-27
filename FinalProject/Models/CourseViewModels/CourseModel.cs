using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models.CourseViewModels
{
    public class CourseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint CourseId { get; set; }
        
        public string Semester { get; set; }
        
        public string Department { get; set; }
        
        public uint CourseNumber { get; set; }
        
        public string Session { get; set; }
        
        public string Instructor { get; set; }
        
        public uint Year { get; set; }
        
        public string Description { get; set; }
        
    }
    
    public class CourseDBContext : DbContext
    {
        public DbSet<CourseModel> Courses { get; set; }
    }
    
}
