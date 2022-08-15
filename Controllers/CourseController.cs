using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        public CourseController(ICourseRepository courseRepository,ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Courses> listcourses = _courseRepository.GetAllCourses();
            return View(listcourses);
        }
        [HttpGet]
        public ViewResult Create()
        {
            List<Teachers> teachersList = _teacherRepository.GetAllTeacher();
            return View(teachersList);//add information users
        }
        [HttpPost]
        public IActionResult Create (Courses course)
        {
            if(course != null)
            {
                _courseRepository.Create(course);
            }
            List<Courses> listcourses = _courseRepository.GetAllCourses();
            return View("Index",listcourses);
        }
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                _courseRepository.Delete(id);
            }
            List<Courses> listcourses = _courseRepository.GetAllCourses();
            return View("Index",listcourses);
        }

    }
}
