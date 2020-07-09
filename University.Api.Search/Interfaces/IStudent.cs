using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Search.Interfaces
{
    public interface IStudent
    {
        Task<(bool IsSucess, dynamic student, string ErrorMsg)> GetStudentByidAsync(int id);
    }
}
