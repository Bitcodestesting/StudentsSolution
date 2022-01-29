using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
    }
}
