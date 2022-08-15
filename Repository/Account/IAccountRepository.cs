using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface IAccountRepository
    {
        public void Login(UserAccount account);
        public void Register(UserAccount account);
    }
}
