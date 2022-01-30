using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using StudentsWebApp.Models;

namespace StudentsWebApp.Controllers
{
    public class CourseController : Controller
    {
        readonly CourseRepository _cRepo;
        //readonly StudentDbContext _db;
        public CourseController(StudentDbContext db)
        {
            _cRepo = new CourseRepository(db);
        }
        public IActionResult Index()
        {
            IEnumerable<Course> courses = _cRepo.GetCourses();
            List<CourseModel> courseModels = new List<CourseModel>();
            if (courses != null && courses.Count() > 0)
            {
                foreach (var item in courses)
                {
                    CourseModel temp = new CourseModel()
                    {
                        CourseId = item.CourseId,
                        CourseName = item.CourseName,
                        CourseDescription = item.CourseDescription
                    };
                    courseModels.Add(temp);
                }
                return View(courseModels);
            }
            else
            {
                ModelState.AddModelError("", "No record found!");
                return View(courseModels);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            CourseModel model = new CourseModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CourseModel model)
        {
            if(model == null || !ModelState.IsValid)
            {
                return View();
            }
            else
            {
                Course course = new Course()
                {
                    CourseId = model.CourseId,
                    CourseDescription = model.CourseDescription,
                    CourseName = model.CourseName
                };
                if (_cRepo.Add(course))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add record!");
                    return View();
                }
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0 || !ModelState.IsValid)
            {
                return View();
            }
            Course c = _cRepo.GetCourseById(id);

            if (c == null)
            {
                ModelState.AddModelError("", "No course is associated with selected!");
                return RedirectToAction("Index");
            }
            else
            {
                CourseModel m = new CourseModel()
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    CourseDescription = c.CourseDescription
                };
                return View(m);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return View();
            }
            Course c = new Course()
            {
                CourseId = model.CourseId,
                CourseName = model.CourseName,
                CourseDescription = model.CourseDescription
            };
            if(_cRepo.Edit(c))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Faild to update record!");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course c = _cRepo.GetCourseById(id);
            if(c != null)
            {
                CourseModel model = new CourseModel()
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    CourseDescription = c.CourseDescription
                };
                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "No course is associated with selected ID!");
                return View() ;
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CourseModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return View();
            }

            else
            {
                if(_cRepo.Delete(model.CourseId))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to delete record!");
                    return View();
                }
            }
        }
    }
}
