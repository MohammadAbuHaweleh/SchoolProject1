using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly MyDbContext _myConnection;
        public AccountRepository (MyDbContext myConnection)
        {
            _myConnection = myConnection;
        }

        public void Login(UserAccount user)
        {
           var usr = _myConnection.userAccount.Single(u => u.UserName == user.UserName && u.Password == user.Password);
           
        }

        public void Register(UserAccount account)
        {
            _myConnection.userAccount.Add(account);
            _myConnection.SaveChanges();
        }
    }
}
