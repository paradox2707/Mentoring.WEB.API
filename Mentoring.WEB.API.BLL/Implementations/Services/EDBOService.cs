using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Models;
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
    public class EDBOService : IEDBOService
    {
        readonly HttpClient _client;

        public EDBOService(HttpClient client)
        {
            _client = client;
        }

        public async Task UpdateUniversities()
        {
            try 
            { 
                var response = await _client.GetAsync("https://registry.edbo.gov.ua/api/universities/?ut=1&exp=json");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var listUniversities = JsonSerializer.Deserialize<List<EDBOUniversityModel>>(responseBody);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
