using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Courses.Model
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Fees { get; set; }

        public int Inventory { get; set; }
    }
}
