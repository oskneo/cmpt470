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
        

       

        public uint CourseId { get; set; }


        public List<FinalProject.Models.QuestionViewModels.QuestionModel> QuestionList { get; set; }

        // public QuestionAndCourse(){
        //     // Title="";
        //     // Description="";
        // }
        
    }
    
    
}




