using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mentoring.Client.Models
{
    public class UniversityModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("specialities")]
        public List<SpecialityModel> Specialities { get; set; }
    }
}