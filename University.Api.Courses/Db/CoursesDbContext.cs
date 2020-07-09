using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Courses.Db
{
    public class CoursesDbContext:DbContext
    {
       

        public DbSet<Course> Courses { get; set; }

        // we can invoke vaious class in same object by using base and pass option
        public CoursesDbContext(DbContextOptions options): base(options)
        {

        }

    }
}
