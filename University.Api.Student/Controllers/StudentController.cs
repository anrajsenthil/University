using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Student.Interface;

namespace University.Api.Student.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsProvider studentProvider;

        public StudentController(IStudentsProvider studentProvider)
        {
            this.studentProvider = studentProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentAsyn()
        {
            var result = await studentProvider.GetStudentysc();
            if (result.IsSuccess)
            {
                return Ok(result.students);
            }
            return NotFound();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await studentProvider.GetStudentByidAysc(id);
            if (result.IsSuccess)
            {
                return Ok(result.student);
            }
            return NotFound();

        }
    }
}
