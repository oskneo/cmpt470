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
    public class CourseAndQuestions
    {
        

       



        public List<FinalProject.Models.QuestionViewModels.QuestionModel> QuestionList { get; set; }

        // public QuestionAndCourse(){
        //     // Title="";
        //     // Description="";
        // }
        
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        // [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{yyyy 0:HH:mm}")]
        public DateTime? Time { get; set; }
        
        
        
        
        
        public uint CourseId { get; set; }



        public CourseAndQuestions(){
            Title="";
            Description="";
        }





        
    }
    
    
}




