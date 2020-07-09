using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Admission.Db
{
    public class AdmissionItems
    {

        public int Id { get; set; }
        public int AdmissionId { get; set; }
        public int CourseId { get; set; }
        public int Quantity { get; set; }
        public decimal unitPrice { get; set; }
    }
}
