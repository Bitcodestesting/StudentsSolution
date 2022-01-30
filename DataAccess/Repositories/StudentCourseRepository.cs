using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class StudentCourseRepository
    {
        readonly StudentDbContext _db;
        public StudentCourseRepository(StudentDbContext dbConetext)
        {
            _db = dbConetext;
        }

        public bool Add(StudentCourse studentCourse)
        {
            bool result = false;
            try
            {
                _db.StudentCourses.Add(studentCourse);
                _db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                result = false;
            }
            return result;
        }

        public StudentCourse GetStudentCourseById(int id)
        {
            StudentCourse studentCourse = new StudentCourse();
            studentCourse = _db.StudentCourses.Find(id);
            return studentCourse;
        }

        public IEnumerable<StudentCourse> GetStudentCourses()
        {
            return _db.StudentCourses.ToList();
        }

        public bool Edit(StudentCourse studentCourse)
        {
            bool result = false;
            if (studentCourse == null)
            {
                result = false;
            }
            else
            {
                try
                {
                    _db.StudentCourses.Update(studentCourse);
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
                StudentCourse studentCourse = GetStudentCourseById(id);
                if (studentCourse != null)
                {
                    _db.StudentCourses.Remove(studentCourse);
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
