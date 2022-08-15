using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Models.View_Model;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;//global variable 
        private readonly ICourseRepository _courseRepository;
        private readonly IHostingEnvironment _Environment;
        public StudentController(IStudentRepository studentRepository , ICourseRepository courseRepository ,
            IHostingEnvironment Environment) //value
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _Environment = Environment;
        }


        //List Of Students
        [HttpGet]
       public ActionResult Index()
        {
            ViewBag.username = "Mohammad";
            ViewData["Message"] = "message";
            List<Student> StudentList = _studentRepository.GetAllStudent();
            return View(StudentList);
        }


        //Render The Creation View
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student ,IFormFile StudentPhoto)
        {

            var wwwrootpath = _Environment.WebRootPath + "/StudentPicture/";

            Guid guid = Guid.NewGuid();

            string fullpath = System.IO.Path.Combine(wwwrootpath, guid + StudentPhoto.FileName);

            using (var filestream = new FileStream(fullpath, FileMode.Create))
            {
                StudentPhoto.CopyTo(filestream); 
            };


                 student.PhotoName = guid + StudentPhoto.FileName;
                _studentRepository.Create(student);
                List<Student> StudentList = _studentRepository.GetAllStudent();
                return View("Index", StudentList);
        }
        public ViewResult Delete(int id)
        {
            
                _studentRepository.Delete(id);
                List<Student> StudentList = _studentRepository.GetAllStudent();
                return View("Index", StudentList);

        }
        [HttpGet]
        public ActionResult Register()
        {
            //int value = TempData["test"];//error becuse dot using casting 
            if(TempData["test"] != null)
            {
                int value = (int)TempData["test"];
                
            }
            
            StudentRegisterVM data = new StudentRegisterVM();
            data.courses= _courseRepository.GetAllCourses();
            data.students = _studentRepository.GetAllStudent();
            return View(data);
        }
        [HttpPost]
        public ActionResult Register(int studentId ,int courseId )
        {
            TempData["test"] = 10;
            
            _studentRepository.Register(studentId, courseId);
            return RedirectToAction("Register");
        }
    }
}
