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
    public class QuestionAnswer
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint AId { get; set; }
        
        // public string Reply { get; set; }
        
        
                
        
        // [DataType(DataType.Time)]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        // public DateTime Time { get; set; }
        

        
        // [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


        // [ForeignKey("QId")]
        public uint QId { get; set; }

        public DateTime Time { get; set; }

        // public virtual QuestionModel Questions { get; set; }

        public string QuestionTitle { get; set; }
        public string QuestionContent { get; set; }
        public List<FinalProject.Models.QuestionViewModels.AnswerModel> Answers { get; set; }

        public QuestionAnswer(){
            AId=0;
        }
        
    }
    
    
}
