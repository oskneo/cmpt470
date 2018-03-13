using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using mvc2.Data;

namespace mvc2.Models.HomeViewModels
{
    
    
    
    public class DataModel
    {
        
        //MySQLConnection
        
        
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        
        
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        
        
        [Display(Name = "Age")]
        public int Age { get; set; }
        
    }
}
