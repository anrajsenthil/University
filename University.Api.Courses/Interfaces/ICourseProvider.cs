using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Courses.Model;

namespace University.Api.Courses.Interfaces
{
    public interface ICourseProvider
    {
        Task<(bool IsSuccess, IEnumerable<Course> courses, String ErrorMsg)> GetCoursesAysc();
        Task<(bool IsSuccess, Course course, String ErrorMsg)> GetCoursesByidAysc(int id);
    }
}
