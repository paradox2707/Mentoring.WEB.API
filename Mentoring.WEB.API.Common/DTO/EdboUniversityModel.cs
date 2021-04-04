using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common.DTO
{
    public class EdboUniversityModel
    {
        public long Id { get; set; }
        [JsonPropertyName("university_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("university_name")]
        public string Name { get; set; }

        [JsonPropertyName("university_short_name")]
        public string ShortName { get; set; }
    }
}
