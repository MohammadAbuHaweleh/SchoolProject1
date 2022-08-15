using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Context
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<UserAccount> userAccount { get; set; }
    }
}
