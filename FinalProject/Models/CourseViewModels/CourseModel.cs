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
        
        [Display(Name = "Semester")]
        public string Semester { get; set; }
        
        [Display(Name = "Department")]
        public string Department { get; set; }
        
        [Display(Name = "CourseNumber")]
        public uint CourseNumber { get; set; }
        
        [Display(Name = "Session")]
        public string Session { get; set; }
        

        [Display(Name = "Instructor")]
        public string Instructor { get; set; }
        
        [Display(Name = "Year")]
        public uint Year { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }
        
    }
    
    
}
