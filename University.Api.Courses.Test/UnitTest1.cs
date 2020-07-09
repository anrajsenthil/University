using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Courses.Db;
using University.Api.Courses.Profile;
using University.Api.Courses.Providers;
using Xunit;

namespace University.Api.Courses.Test
{
    public class CourseServiceTest
    {
        [Fact]
        public async Task GetCourseReturnsAllCourses()
        {
            var option = new DbContextOptionsBuilder<CoursesDbContext>()
                .UseInMemoryDatabase(nameof(GetCourseReturnsAllCourses))
                .Options;

            var dbContext = new CoursesDbContext(option);
            CreateCourse(dbContext);

            var courseProfile = new CourseProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(courseProfile));
            var mapper = new Mapper(config);
            var courseProvide = new CoursesProvider(dbContext, null, mapper);

           var course= await courseProvide.GetCoursesAysc();
            Assert.True(course.IsSuccess);
            Assert.True(course.courses.Any());
            Assert.Null(course.ErrorMsg);
        }

        private void CreateCourse(CoursesDbContext dbContext)
        {
            for(int i=0;i<=10;i++)
            {

                dbContext.Courses.Add(new Course()
                {

                    Id=i+100,
                    Name=Guid.NewGuid().ToString(),
                    Inventory=i+10,
                    Fees=(decimal)(i*3.14 )
                    

                });
            }
            dbContext.SaveChanges();
        }


        [Fact]
        public async Task GetCourseReturnsCoursesUsingValidId()
        {
            var option = new DbContextOptionsBuilder<CoursesDbContext>()
                .UseInMemoryDatabase(nameof(GetCourseReturnsCoursesUsingValidId))
                .Options;

            var dbContext = new CoursesDbContext(option);
            CreateCourse(dbContext);

            var courseProfile = new CourseProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(courseProfile));
            var mapper = new Mapper(config);
            var courseProvide = new CoursesProvider(dbContext, null, mapper);

            var course = await courseProvide.GetCoursesByidAysc(101);
            Assert.True(course.IsSuccess);
            Assert.NotNull(course.course);
            Assert.True(course.course.Id==101);
            Assert.Null(course.ErrorMsg);
        }
        [Fact]
        public async Task GetCourseReturnsCoursesUsingInValidId()
        {
            var option = new DbContextOptionsBuilder<CoursesDbContext>()
                .UseInMemoryDatabase(nameof(GetCourseReturnsCoursesUsingInValidId))
                .Options;

            var dbContext = new CoursesDbContext(option);
            CreateCourse(dbContext);

            var courseProfile = new CourseProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(courseProfile));
            var mapper = new Mapper(config);
            var courseProvide = new CoursesProvider(dbContext, null, mapper);

            var course = await courseProvide.GetCoursesByidAysc(-1);
            Assert.False(course.IsSuccess);
            Assert.Null(course.course);
            Assert.NotNull(course.ErrorMsg);
        }


    }
}
