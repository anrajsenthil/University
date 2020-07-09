using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Student.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int Phone { get; set; }
    }
}
