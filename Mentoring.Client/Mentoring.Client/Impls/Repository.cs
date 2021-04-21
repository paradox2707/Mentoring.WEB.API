using Mentoring.Client.Abstract;
using Mentoring.Client.Models;
using System.Collections.Generic;
using System.Net.Http;
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

        public async Task<List<SpecialityModel>> GetSpecialitiesAsync()
        {
            var response = await _client.GetAsync("https://localhost:44386/api/Speciality");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<SpecialityModel>>(responseBody);
        }

        public async Task<List<UniversityModel>> GetUniversitiesAsync()
        {
            var response = await _client.GetAsync("https://localhost:44386/api/University");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<UniversityModel>>(responseBody);
        }

        public async Task<List<UniversityModel>> GetUniversitiesWithSpecialitiesAsync()
        {
            var response = await _client.GetAsync("https://localhost:44386/api/University/Specialities");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<UniversityModel>>(responseBody);
        }
    }
}