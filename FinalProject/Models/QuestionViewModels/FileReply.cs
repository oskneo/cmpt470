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
using Microsoft.AspNetCore.Http;

namespace FinalProject.Models.QuestionViewModels
{
    public class FileReply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint AnswerId { get; set; }
        
        [Display(Name = "Reply")]
        public string Reply { get; set; }
        
        
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        // public DateTime Date { get; set; }
        
        
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Time { get; set; }
        

        
        // [ForeignKey("UserId")]
        // public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserName{ get; set; }


        [ForeignKey("QId")]
        public uint QId { get; set; }

        public virtual QuestionModel Questions { get; set; }

        public uint RefAId { get; set; }
        
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        
        public bool FileUploaded { get; set;}

        // public uint FileId { get; set; }
        // public virtual FileModel Files { get; set; }


        public FileReply(){
            Reply="";
            FileUploaded=false;
        }
        
    }
    
    
}
