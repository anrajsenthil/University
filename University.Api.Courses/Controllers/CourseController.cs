using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Courses.Interfaces;
using University.Api.Courses.Providers;

namespace University.Api.Courses.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController:ControllerBase
    {
        private readonly ICourseProvider coursesProvider;

        public CourseController(ICourseProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseAsyn()
        {
           var result=await coursesProvider.GetCoursesAysc();
            if (result.IsSuccess)
            {
                return Ok(result.courses);
            }
            return NotFound();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByIdAsyn(int id)
        {
            var result = await coursesProvider.GetCoursesByidAysc(id);
            if (result.IsSuccess)
            {
                return Ok(result.course);
            }
            return NotFound();

        }
    }
}
