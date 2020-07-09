using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Admission.Interface
{
   public interface IAdmissionProvider
    {
                                                                                        
        Task<(bool IsSuccess, IEnumerable<Model.Admission> admission, string ErrorMsg)> GetAdmissionAysc(int StudentId);
      //  Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
