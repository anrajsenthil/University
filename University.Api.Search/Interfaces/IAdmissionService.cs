using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Search.Model;

namespace University.Api.Search.Interfaces
{
    public interface IAdmissionService
    {

        Task<(bool IsSucess,IEnumerable<Admission> admissions,string ErrorMsg)> GetAdmissionAsync(int StudentId);
            
    }
}
