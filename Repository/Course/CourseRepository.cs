using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MyDbContext _myConnection;
        public CourseRepository(MyDbContext myConnection)
        {
            _myConnection = myConnection;
        }
        public void Create(Courses course)
        {
            _myConnection.Courses.Add(course);
            _myConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Courses course = (from obj in _myConnection.Courses
                              where obj.CourseId == id
                              select obj).FirstOrDefault();
            _myConnection.Courses.Remove(course);
            _myConnection.SaveChanges();
        }

        public List<Courses> GetAllCourses()
        {
            List<Courses> course = (from obj in _myConnection.Courses
                                    select obj).ToList();
            return course;
        }
    }
}
