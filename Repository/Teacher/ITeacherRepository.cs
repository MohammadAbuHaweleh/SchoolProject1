using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
   public interface ITeacherRepository
    {
        public List<Teachers> GetAllTeacher();
        public void Create(Teachers teachers);
        public void Delete(int id);

    }
    
}
