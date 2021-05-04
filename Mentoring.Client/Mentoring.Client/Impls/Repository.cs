using Mentoring.Client.Abstract;
using Mentoring.Client.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mentoring.Client.Impls
{
    public class Repository : IRepository
    {
        private readonly HttpClient _client;

        public Repository(HttpClient client)
        {
            this._client = client;
        }

        public async Task CreateApplication(ApplicationModel dto)
        {
            JsonContent content = JsonContent.Create(dto);
            await _client.PostAsync("https://localhost:44386/api/UserApplication", content);
        }

        public async Task<string[]> GetProfessionalDirectionNamesAsync()
        {
            string responseBody = await RequestForSimpleModel("ProfessionalDirection");
            return JsonSerializer.Deserialize<List<ProfessionalDirectionModel>>(responseBody).Select(m => m.Name).ToArray();
        }

        public async Task<string[]> GetRegionNamesAsync()
        {
            string responseBody = await RequestForSimpleModel("Region");
            return JsonSerializer.Deserialize<List<RegionModel>>(responseBody).Select(m => m.Name).ToArray();
        }

        public async Task<List<SpecialityModel>> GetSpecialitiesAsync()
        {
            var responseBody = await RequestForSimpleModel("Speciality");
            return JsonSerializer.Deserialize<List<SpecialityModel>>(responseBody);
        }

        public async Task<List<UniversityModel>> GetUniversitiesAsync()
        {
            var responseBody = await RequestForSimpleModel("University");
            return JsonSerializer.Deserialize<List<UniversityModel>>(responseBody);
        }

        public async Task<List<UniversityModel>> GetUniversitiesWithSpecialitiesAsync()
        {
            var responseBody = await RequestForSimpleModel("University/Specialities");
            return JsonSerializer.Deserialize<List<UniversityModel>>(responseBody);
        }

        private async Task<string> RequestForSimpleModel(string path)
        {
            var response = await _client.GetAsync($"https://localhost:44386/api/{path}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}