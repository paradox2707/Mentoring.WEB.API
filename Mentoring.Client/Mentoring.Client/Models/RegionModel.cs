using System.Text.Json.Serialization;

namespace Mentoring.Client.Models
{
    public class RegionModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}