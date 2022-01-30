using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace DataAccess.Repositories
{
    public class CourseRepository
    {
        readonly StudentDbContext _db;
        public CourseRepository(StudentDbContext dbContext)
        {
            _db = dbContext;
        }

        public bool Add(Course course)
        {
            bool result = false;
            try
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                result = true;
            }
            catch(Exception ex)
            {
                new Exception(ex.Message);
                result = false;
            }
            return result;
        }

        public Course GetCourseById(int id)
        {
            Course course = new Course();
            course = _db.Courses.Find(id);
            return course;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _db.Courses.ToList();
        }

        public bool Edit(Course course)
        {
            bool result = false;
            if (course == null)
            {
                result = false;
            }
            else
            {
                try
                {
                    _db.Courses.Update(course);
                    _db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    new Exception(ex.Message);
                    result = false;
                }
            }
            return result;


        }

        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                Course course = GetCourseById(id);
                if (course != null)
                {
                    _db.Courses.Remove(course);
                    _db.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                result = false;
            }

            return result;
        }
    }
}
