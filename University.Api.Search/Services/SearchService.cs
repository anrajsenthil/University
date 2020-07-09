using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Search.Interfaces;

namespace University.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IAdmissionService admissionService;
        private readonly ICourses coursesService;
        private readonly IStudent studentservice;

        public SearchService(IAdmissionService admissionService, ICourses coursesService, IStudent studentservice)
        {
            this.admissionService = admissionService;
           this.coursesService = coursesService;
            this.studentservice = studentservice;
        }

        public ICourses CoursesService { get; }

        public async Task<(bool IsSucess, dynamic searchResult)> SearchAsyn(int studentId)
        {

            var admissionResult = await admissionService.GetAdmissionAsync(studentId);
            var courseResult = await coursesService.GetCoursesAsync();
            var studentResult = await studentservice.GetStudentByidAsync(studentId);
            if (admissionResult.IsSucess)
            {
                foreach(var _admission in admissionResult.admissions)
                {
                    foreach (var course in _admission.CourseList)
                    {
                        course.Name = courseResult.IsSucess ? courseResult.course.FirstOrDefault(c => c.Id == course.CourseId)?.Name : "Course Information is not available";
                    }
                }

                //var result = new
                //{
                //    admission = admissionResult.admissions
                //};
                //return (true, result);

                var result = new
                {
                    Student = studentResult.IsSucess ?
                                    studentResult.student :
                                    new { Name = "Student information is not available" },
                    admission = admissionResult.admissions
                };
                return (true, result);
            }
            return (false, null);
           // await Task.Delay(1);
           // return (true, new { Message = "Hello" });

        }
    }
}
