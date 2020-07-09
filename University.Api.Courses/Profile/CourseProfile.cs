using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Courses.Profile
{
    public class CourseProfile : AutoMapper.Profile
    {
        public CourseProfile()
        {
            CreateMap<Db.Course, Model.Course>();
        }
    }
}
