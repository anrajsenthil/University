using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Student.Db
{
    public class StudentDbContext:DbContext
    {

        public DbSet<Student> Students { get; set; }

        // we can invoke vaious class in same object by using base and pass option
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
