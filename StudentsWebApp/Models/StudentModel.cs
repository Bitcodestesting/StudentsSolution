using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentsWebApp.Models
{
    public class StudentModel
    {
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }

        [Display(Name ="Student Name")]
        [Required]
        public string StudentName { get; set; }
    }
}
