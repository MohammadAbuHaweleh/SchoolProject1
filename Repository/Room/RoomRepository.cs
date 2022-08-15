using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDbContext _MyConnection;
        public RoomRepository(MyDbContext MyConnection)
        {
            _MyConnection = MyConnection;
        }
        public void Create(Rooms rooms)
        {
            _MyConnection.Rooms.Add(rooms);
            _MyConnection.SaveChanges();
        }

        public void Delete(int id)
        {

            Rooms room = (from obj in _MyConnection.Rooms
                          where obj.RoomId == id 
                          select obj).FirstOrDefault();
            _MyConnection.Rooms.Remove(room);
            _MyConnection.SaveChanges();
        }

        public List<Rooms> GetAllRoom()
        {
            List<Rooms> rooms = (from obj in _MyConnection.Rooms
                                 select obj).ToList();
            return rooms;
        }
    }
}
