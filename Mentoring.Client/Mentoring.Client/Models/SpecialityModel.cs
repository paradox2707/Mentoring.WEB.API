using System.Text.Json.Serialization;

namespace Mentoring.Client.Models
{
    public class SpecialityModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
