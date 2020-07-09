using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Api.Search.Interfaces
{
    public interface ISearchService
    {

        Task<(bool IsSucess, dynamic searchResult)> SearchAsyn(int studentId);
    }
}
