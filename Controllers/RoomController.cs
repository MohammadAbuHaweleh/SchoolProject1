using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult Index()//GetAllRoom
        {
            List<Rooms> listRoom = _roomRepository.GetAllRoom();

            return View(listRoom);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Rooms rooms)
        {
            if(rooms != null)
            {
                _roomRepository.Create(rooms);
            }
            List<Rooms> listRoom = _roomRepository.GetAllRoom();

            return View("Index", listRoom);
        }

        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                _roomRepository.Delete(id);
            }
            List<Rooms> listRoom = _roomRepository.GetAllRoom();

            return View("Index", listRoom);
        }
    }
}
