using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public IActionResult Index() //return all teachers
        {
            List<Teachers> teachersList = _teacherRepository.GetAllTeacher();
            return View(teachersList);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Teachers teacher)
        {
            if(teacher != null)
            {
                _teacherRepository.Create(teacher);
            }
            List<Teachers> teachersList = _teacherRepository.GetAllTeacher();

            return View("Index", teachersList);
        }
        public IActionResult Delete(int id)
        {
            if(id > 0)//because dont using (- or 0) 
            {
                _teacherRepository.Delete(id);
            }
            List<Teachers> teachersList = _teacherRepository.GetAllTeacher();
            return View("Index", teachersList);
        }
    }
}
