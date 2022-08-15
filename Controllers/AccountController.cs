using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                _accountRepository.Register(account);
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + "successfully registered.";
            }
           
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            _accountRepository.Login(user);
            return RedirectToAction("Index");
        }
        

    }
}
