using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class StudentRepoistory : IStudentRepository
    {
        private readonly MyDbContext _myDbConnection;
        public StudentRepoistory(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }
        public List<Student> GetAllStudent()
        {
            try
            {
                List<Student> students = (from std in _myDbConnection.Students
                                          select std).ToList();
                return students;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //insert the error in the database
                return null;
            }

            
                
        }
        public void Create(Student student)
        {

            _myDbConnection.Students.Add(student);
            _myDbConnection.SaveChanges();
        }
        public void Delete(int id)
        {
            Student std = (from obj in _myDbConnection.Students
                           where obj.StudentId == id 
                           select obj).FirstOrDefault();

            //return one value student by studentName
            //string studentName = (from obj in _myDbConnection.Students
            //                      select obj.StudentName).FirstOrDefault();
            
            
            _myDbConnection.Students.Remove(std);
            _myDbConnection.SaveChanges();
        }
        public void Register(int studentId, int courseId)
        {
            ////add  student to make studentId register courseId
            //StudentCourse obj = new StudentCourse();
            //obj.CourseId = courseId;
            //obj.StudentId = studentId;
            //_myDbConnection.StudentCourses.Add(obj);
            //_myDbConnection.SaveChanges();

            _myDbConnection.StudentCourses.Add(new StudentCourse

             {
               CourseId = courseId,
               StudentId = studentId,
             });
            _myDbConnection.SaveChanges();
        }
    }
}
