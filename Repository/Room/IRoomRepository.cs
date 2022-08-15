using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
   public interface IRoomRepository
    {
        public List<Rooms> GetAllRoom();
        public void Create(Rooms rooms);
        public void Delete(int id);

    }
}
