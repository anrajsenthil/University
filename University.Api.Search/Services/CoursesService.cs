using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using University.Api.Search.Interfaces;
using University.Api.Search.Model;

namespace University.Api.Search.Services
{
    public class CoursesService : ICourses
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<CoursesService> logger;
        public CoursesService(IHttpClientFactory httpClientFactory, ILogger<CoursesService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSucess, IEnumerable<Course> course, string ErrorMsg)> GetCoursesAsync()
        {
            try
            {
                var client = httpClientFactory.CreateClient("CoursesService");

                var response = await client.GetAsync($"api/course");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Course>>(content, option);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
