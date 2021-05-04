using System.Text.Json.Serialization;

namespace Mentoring.Client.Models
{
    public class ProfessionalDirectionModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}