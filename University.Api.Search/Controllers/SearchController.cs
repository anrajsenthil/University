using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Api.Search.Interfaces;
using University.Api.Search.Model;

namespace University.Api.Search.Controllers
{

    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsyn(term.StudentId);
            if(result.IsSucess)
            {
                return Ok(result.searchResult);
            }

            return NotFound();

        }
    }
}
