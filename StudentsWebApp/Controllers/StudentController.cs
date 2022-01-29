using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.Repositories;
using StudentsWebApp.Models;
namespace StudentsWebApp.Controllers
{
    public class StudentController : Controller
    {
        readonly StudentDbContext _db;
        readonly StudentRepository stuRepo;
        public StudentController(StudentDbContext db)
        {
            _db = db;
            stuRepo = new StudentRepository(_db);
        }
        /// <summary>
        /// Get List of All students
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Student> s = stuRepo.GetAllStudents();
            List<StudentModel> m = new List<StudentModel>();
            if(s!= null)
            {
                foreach(var item in s)
                {
                    StudentModel temp = new StudentModel()
                    {
                        StudentId = item.StudentId,
                        StudentName = item.StudentName
                    };
                    m.Add(temp);
                }
            }
            return View(m);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
