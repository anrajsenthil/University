using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using University.Api.Search.Interfaces;
using University.Api.Search.Model;
using System.Text.Json;
namespace University.Api.Search.Services
{
    public class AdmissionService : IAdmissionService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<AdmissionService> logger;

        public AdmissionService(IHttpClientFactory httpClientFactory,ILogger<AdmissionService> logger )
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSucess, IEnumerable<Admission> admissions, string ErrorMsg)> GetAdmissionAsync(int StudentId)
        {
            
            try
            {
                var client = httpClientFactory.CreateClient("AdmissionService");
               
                var response = await client.GetAsync($"api/admission/{StudentId}");
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Admission>>(content,option);
                    return (true, result, null);
                }
                return (false, null,response.ReasonPhrase);
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
