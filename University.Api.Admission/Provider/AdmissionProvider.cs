using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Admission.Db;
using University.Api.Admission.Interface;


namespace University.Api.Admission.Provider
{
    public class AdmissionProvider: IAdmissionProvider
    {
        private readonly AdmissionDbContext dbContext;
        private readonly ILogger<AdmissionProvider> logger;
        private readonly IMapper mapper;

        public AdmissionProvider(AdmissionDbContext dbContext, ILogger<AdmissionProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.admissions.Any())
            {
                dbContext.admissions.Add(new Db.Admission()
                {
                    Id = 1,
                    StudentId = 1,
                    AdmissionDate = DateTime.Now,
                    CourseList = new List<AdmissionItems>()
                    {
                        new AdmissionItems() { AdmissionId = 1, CourseId = 1, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 1, CourseId = 2, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 1, CourseId = 3, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 2, CourseId = 2, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 3, CourseId = 3, Quantity = 1, unitPrice = 100 }
                    },
                    TotalFees = 100
                });
                dbContext.admissions.Add(new Db.Admission()
                {
                    Id = 2,
                    StudentId = 1,
                    AdmissionDate = DateTime.Now.AddDays(-1),
                    CourseList = new List<AdmissionItems>()
                    {
                        new AdmissionItems() { AdmissionId = 1, CourseId = 1, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 1, CourseId = 2, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 1, CourseId = 3, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 2, CourseId = 2, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 3, CourseId = 3, Quantity = 1, unitPrice = 100 }
                    },
                    TotalFees = 100
                });
                dbContext.admissions.Add(new Db.Admission()
                {
                    Id = 3,
                    StudentId = 2,
                    AdmissionDate = DateTime.Now,
                    CourseList = new List<AdmissionItems>()
                    {
                        new AdmissionItems() { AdmissionId = 1, CourseId = 1, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 2, CourseId = 2, Quantity = 10, unitPrice = 10 },
                        new AdmissionItems() { AdmissionId = 3, CourseId = 3, Quantity = 1, unitPrice = 15 }
                    },
                    TotalFees = 100
                });
                dbContext.SaveChanges();
            }
        }
                     
        public async Task<(bool IsSuccess, IEnumerable<Model.Admission> admission, string ErrorMsg)> GetAdmissionAysc(int stuid)
        {
            try
            {
                var ad = await dbContext.admissions
                    .Where(o => o.StudentId == stuid)
                    .Include(o => o.CourseList)
                    .ToListAsync();
                if (ad != null && ad.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Admission>,
                        IEnumerable<Model.Admission>>(ad);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

      
    }
}
