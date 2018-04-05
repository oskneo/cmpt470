using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models.EventViewModels
{
    public class GetEvents
    {
        
        // public uint EventId { get; set; }

        
        
        public DateTime Time { get; set; }
        
        public string Location { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        

        public string UserName { get; set; }

        public string Email { get; set; }
        
        public GetEvents(){
            Title="";
        }
        
        
    }
    
    
}
