using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Search.Model
{
    public class AdmissionItems
    {

        public int Id { get; set; }
        public int CourseId { get; set; }
       public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal unitPrice { get; set; }
    }
}
