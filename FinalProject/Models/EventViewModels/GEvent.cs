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

namespace FinalProject.Models.EventViewModels
{
    public class GEvent
    {
        public uint EventId { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        
        [Required]
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Time { get; set; }
        
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        public int NumberOfSeats { get; set; }
        
        public int OccupiedSeats { get; set; }
        
        public uint GroupNumber { get; set; }
        
        public uint CourseId { get; set; }
        
        public GEvent(){
            Title="";
        }
        
        
    }
    
    
}
