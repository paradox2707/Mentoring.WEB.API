using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class EdboService : IEdboService
    {
        readonly HttpClient _client;

        public EdboService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<EdboUniversityModel>> GetAllUniversities()
        {
            try 
            { 
                var response = await _client.GetAsync("https://registry.edbo.gov.ua/api/universities/?ut=1&exp=json");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<EdboUniversityModel>>(responseBody);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}
