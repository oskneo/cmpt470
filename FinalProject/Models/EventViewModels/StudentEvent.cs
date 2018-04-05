using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;


namespace FinalProject.Models.EventViewModels
{
    public class StudentEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint StudentEventId { get; set; }

        [ForeignKey("Events")]
        public uint EventId { get; set; }

        public virtual EventModel Events { get; set; }
        
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        public StudentEvent(){
            EventId=0;
        }
        
        
    }
    
    // public class StudentCourseDBContext : DbContext
    // {
        
    // }
    
}
