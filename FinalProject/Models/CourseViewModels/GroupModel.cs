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

namespace FinalProject.Models.CourseViewModels
{
    public class GroupModel
    {
        

        public uint CourseId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        public List<SCG> GroupMembers { get; set; }

        public List<SCG> StudentCourses { get; set; }

        public uint GroupNumber { get; set; }

        public string userid { get; set; }

        public GroupModel(){
            GroupNumber=0;
        }

        
        
    }
    
    // public class StudentCourseDBContext : DbContext
    // {
        
    // }
    
}
