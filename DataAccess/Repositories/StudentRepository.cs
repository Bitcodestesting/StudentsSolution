using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /// <summary>
        /// Add a new student to the table
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Add(Student s)
        {
            bool result = false;
            if(s== null)
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
                catch(Exception ex)
                {
                    new Exception(ex.Message);
                    result = false;
                }
            }
            return result;
        }


        public IEnumerable<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }
    }
}
