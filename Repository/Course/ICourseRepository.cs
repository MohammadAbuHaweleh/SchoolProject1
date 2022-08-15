using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface ICourseRepository
    {
        public List<Courses> GetAllCourses();
        public void Create(Courses course);
        public void Delete(int id);
    }
}
