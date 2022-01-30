using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace StudentsWebApp.Models
{
    public class CourseModel
    {

        [Key]
        [Display(Name ="Course Id")]
        public int CourseId { get; set; }

        [Required]
        [Display(Name ="Course Name")]
        [StringLength(30, MinimumLength =3,ErrorMessage ="The {0} lenght must be between {2} and {1}")]
        public string CourseName { get; set; }

        [Display(Name ="Description")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "The {0} lenght must be between {2} and {1}")]
        public string CourseDescription { get; set; }
    }
}
