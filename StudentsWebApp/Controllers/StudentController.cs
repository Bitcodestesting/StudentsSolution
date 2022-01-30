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
            StudentModel m = new StudentModel();
            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(StudentModel m)
        {
            if(!ModelState.IsValid || m == null)
            {
                return View();
            }
            else
            {
                Student s = new Student()
                {
                    StudentId = m.StudentId,
                    StudentName = m.StudentName
                };
                stuRepo.Add(s);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0 || !ModelState.IsValid)
            {
                return View();
            }
            Student s = stuRepo.GetStudentById(id);
            
            if (s == null)
            {
                ModelState.AddModelError("", "No student is associated with selected - {id}");
                return View();
            }
            else
            {
                StudentModel m = new StudentModel()
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName
                };
                return View(m);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel s)
        {
            if (s == null || !ModelState.IsValid)
            {
                return View();
            }
            Student student = new Student()
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName
            };

            stuRepo.Update(student);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Delete selected student by student ID
        /// </summary>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student s = stuRepo.GetStudentById(id);
            if(s != null)
            {
                StudentModel model = new StudentModel()
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName
                };
                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "Student details not available!");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StudentModel model)
        {
            if(model != null || !ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if(stuRepo.Delete(model.StudentId) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
        }
    }
}
