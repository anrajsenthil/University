using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Student.Interface
{
   public interface IStudentsProvider
    {

        Task<(bool IsSuccess, IEnumerable<Model.Student> students, String ErrorMsg)> GetStudentysc();
        Task<(bool IsSuccess, Model.Student student, String ErrorMsg)> GetStudentByidAysc(int id);
    }
}
