using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Models;
using FinalProject.Models.CourseViewModels;

namespace FinalProject.Models.QuestionViewModels
{
    public class QuestionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint QId { get; set; }
        
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        
        
        
        
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Time { get; set; }
        

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Courses")]
        [ForeignKey("Courses")]
        public uint CourseId { get; set; }

        public virtual CourseModel Courses { get; set; }
        
    }
    
    
}
