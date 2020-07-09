using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using University.Api.Search.Interfaces;

namespace University.Api.Search.Services
{
    public class StudentService : IStudent
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<StudentService> logger;
        public StudentService(IHttpClientFactory httpClientFactory, ILogger<StudentService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        
        public async Task<(bool IsSucess, dynamic student, string ErrorMsg)> GetStudentByidAsync(int id)
        {
          
            try
            {
                var client = httpClientFactory.CreateClient("StudentService");

                var response = await client.GetAsync($"api/student/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<dynamic>(content, option);
                    return (true, result ,null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }




        }
    }
}
