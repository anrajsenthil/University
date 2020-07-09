using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Search.Model;

namespace University.Api.Search.Interfaces
{
    public interface ICourses
    {
        Task<(bool IsSucess, IEnumerable<Course> course, string ErrorMsg)> GetCoursesAsync();
    }
}
