using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Admission.Interface;

namespace University.Api.Admission.Controllers
{
    [ApiController]
    [Route("api/admission")]
    public class AdmissionController: ControllerBase
    {

        private readonly IAdmissionProvider admissionProvider;

        public AdmissionController(IAdmissionProvider admissionProvider)
        {
            this.admissionProvider = admissionProvider;
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetOrdersAsync(int studentId)
        {
            var result = await admissionProvider.GetAdmissionAysc(studentId);
            if (result.IsSuccess)
            {
                return Ok(result.admission);
            }
            return NotFound();
        }

    }
}
