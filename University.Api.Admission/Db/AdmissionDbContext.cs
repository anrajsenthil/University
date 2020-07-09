using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Admission.Db
{
    public class AdmissionDbContext:DbContext
    {

        public DbSet<Admission> admissions { get; set; }

        // we can invoke vaious class in same object by using base and pass option
        public AdmissionDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
