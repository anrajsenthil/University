using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Courses.Db;
using University.Api.Courses.Interfaces;
using University.Api.Courses.Model;

namespace University.Api.Courses.Providers
{
    public class CoursesProvider : ICourseProvider
    {
        private readonly CoursesDbContext dbContext;
        private readonly ILogger<CoursesProvider> logger;
        private readonly IMapper mapper;

        public CoursesProvider(CoursesDbContext dbContext,ILogger<CoursesProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if(!dbContext.Courses.Any())
            {
                dbContext.Courses.Add(new Db.Course() { Id = 1, Name = "Medicine", Fees = 50000, Inventory = 500 });
                dbContext.Courses.Add(new Db.Course() { Id = 2, Name = "Nurcing", Fees = 10000, Inventory = 100 });
                dbContext.Courses.Add(new Db.Course() { Id = 3, Name = "Dentel", Fees = 40000, Inventory = 400 });
                dbContext.Courses.Add(new Db.Course() { Id = 4, Name = "Engineering", Fees = 20000, Inventory = 200 });
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Model.Course> courses, string ErrorMsg)> GetCoursesAysc()
        {
            try
            {
                var course = await dbContext.Courses.ToListAsync();
                if(course!=null && course.Any())
                {
                   var result= mapper.Map<IEnumerable<Db.Course>, IEnumerable<Model.Course>>(course);
                    return (true, result, null);
                }
                return (false, null, "not found");
                    
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }


       public  async Task<(bool IsSuccess, Model.Course course, string ErrorMsg)> GetCoursesByidAysc(int id)
        {
            try
            {
                var course = await dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
                if (course != null)
                {
                    var result = mapper.Map<Db.Course, Model.Course>(course);
                    return (true, result, null);
                }
                return (false, null, "not found");

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }


}
