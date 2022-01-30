using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
namespace DataAccess.Repositories
{
    public class StudentRepository
    {
        readonly StudentDbContext _db;
        public StudentRepository(StudentDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }
        /// <summary>
        /// Add a new student to the table
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Add(Student s)
        {
            bool result = false;
            if (s == null)
            {
                result = false;
            }
            else
            {
                try
                {
                    _db.Students.Add(s);
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

        public Student GetStudentById(int? id)
        {
            return _db.Students.Find(id);
        }

        /// <summary>
        /// Update students
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool Update(Student student)
        {
            bool result = false;
            if (student == null)
            {
                result = false;
            }
            else
            {
                try
                {
                    _db.Students.Update(student);
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
    }

}
