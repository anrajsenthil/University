using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Admission.Profile
{
    public class AdmissionProfile:AutoMapper.Profile
    {
        public  AdmissionProfile()
        {
            CreateMap<Db.Admission, Model.Admission>();
            CreateMap<Db.AdmissionItems, Model.AdmissionItem>();
        }
       
    }
}
