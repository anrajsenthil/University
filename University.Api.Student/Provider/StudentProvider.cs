using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Student.Db;
using University.Api.Student.Interface;
using University.Api.Student.Model;

namespace University.Api.Student.Provider
{
    public class StudentProvider : IStudentsProvider
    {

        private readonly StudentDbContext dbContext;
        private readonly ILogger<StudentProvider> logger;
        private readonly IMapper mapper;

        public StudentProvider(StudentDbContext dbContext, ILogger<StudentProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Students.Any())
            {
                dbContext.Students.Add(new Db.Student() { Id = 1, Name = "Medicine", Address = "chennai", Phone = 500 });
                dbContext.Students.Add(new Db.Student() { Id = 2, Name = "Nurcing", Address = "Karaikudi", Phone = 100 });
                dbContext.Students.Add(new Db.Student() { Id = 3, Name = "Dentel", Address = "Madurai", Phone = 400 });
                dbContext.Students.Add(new Db.Student() { Id = 4, Name = "Engineering", Address = "Thiruppatur", Phone = 200 });
                dbContext.SaveChanges();
            }
        }

       public async Task<(bool IsSuccess, IEnumerable<Model.Student> students, string ErrorMsg)> GetStudentysc()
        {
            try
            {
                var course = await dbContext.Students.ToListAsync();
                if (course != null && course.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Student>, IEnumerable<Model.Student>>(course);
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

        public async Task<(bool IsSuccess, Model.Student student, string ErrorMsg)> GetStudentByidAysc(int id)
        {
            try
            {
                var course = await dbContext.Students.FirstOrDefaultAsync(c => c.Id == id);
                if (course != null)
                {
                    var result = mapper.Map<Db.Student, Model.Student>(course);
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

