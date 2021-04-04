using Mentoring.Client.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mentoring.Client.Impls
{
    internal class Repository : IRepository
    {
        private readonly HttpClient _client;

        public Repository(HttpClient client)
        {
            this._client = client;
        }

        public async Task<List<UniversityModel>> GetUniversityAsync()
        {
            var response = await _client.GetAsync("https://localhost:44386/api/University");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<UniversityModel>>(responseBody);
        }
    }
}