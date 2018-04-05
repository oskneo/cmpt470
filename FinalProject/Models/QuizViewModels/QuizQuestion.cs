using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using FinalProject.Models.CourseViewModels;

namespace FinalProject.Models.QuizViewModels
{
    public class QuizQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint QuizQuestionId { get; set; }

        [ForeignKey("Quizs")]
        public uint QuizId { get; set; }

        public virtual CourseModel Quizs { get; set; }


        
        public uint Index { get; set; }
        
        [Required]
        [Display(Name = "Question")]
        public string Question { get; set; }

        [Required]
        [Display(Name = "AnswerA")]
        public string AnswerA { get; set; }

        [Required]
        [Display(Name = "AnswerB")]
        public string AnswerB { get; set; }

        [Required]
        [Display(Name = "AnswerC")]
        public string AnswerC { get; set; }

        [Required]
        [Display(Name = "AnswerD")]
        public string AnswerD { get; set; }

        [Required]
        [Display(Name = "CorrectAnswer(Input A, B, C or D)")]
        public char CorrectAnswer { get; set; }
        
        public bool Finished { get; set; }
        
        public QuizQuestion(){
            Question="";
            Finished=false;
        }
        
        
    }
    
    
}





