using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Student.Profile
{
    public class StudentProfile : AutoMapper.Profile
    {

        public StudentProfile()
        {
            CreateMap<Db.Student, Model.Student>();
        }
    }
}
