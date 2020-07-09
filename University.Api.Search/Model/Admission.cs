using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Search.Model
{
    public class Admission
    {

        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public decimal TotalFees { get; set; }
        public List<AdmissionItems> CourseList { get; set; }
    }
}
