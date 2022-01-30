using System.ComponentModel.DataAnnotations;
namespace StudentsWebApp.Models
{
    public class StudentCourseModel
    {
        [Required]
        [Display(Name ="Student")]
        public int StudentId { get; set; }
        [Required]
        [Display(Name ="Course")]
        public int CourseId { get; set; }

        public virtual CourseModel Course { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}
