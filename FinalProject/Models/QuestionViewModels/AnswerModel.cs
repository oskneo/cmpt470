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
    public class AnswerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint AnswerId { get; set; }
        
        [Required]
        [Display(Name = "Reply")]
        public string Reply { get; set; }
        
        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please enter a start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Time { get; set; }
        

        
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("QId")]
        public uint QId { get; set; }

        public virtual QuestionModel Questions { get; set; }
        
    }
    
    
}
