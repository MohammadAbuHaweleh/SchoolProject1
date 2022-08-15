using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDbContext _myConnection;
        public TeacherRepository(MyDbContext myConnection)
        {
            _myConnection = myConnection;
        }
        public List<Teachers> GetAllTeacher()
        {
            try
            {
                List<Teachers> teachers = (from obj in _myConnection.Teachers
                                           select obj).ToList();
                return teachers;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return null;
            }
            
        }
        public void Create(Teachers teachers)
        {
            _myConnection.Teachers.Add(teachers);
            _myConnection.SaveChanges();

           
        }

        public void Delete(int id)
        {
            Teachers teacher = (from obj in _myConnection.Teachers
                                 where obj.TeacherId == id
                                 select obj).FirstOrDefault();
            _myConnection.Teachers.Remove(teacher);
            _myConnection.SaveChanges();
        }

        
    }
}
