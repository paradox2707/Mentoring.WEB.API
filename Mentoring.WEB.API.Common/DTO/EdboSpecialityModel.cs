using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common.DTO
{
    public class EdboSpecialityModel
    {
        public long Id { get; set; }
        [JsonPropertyName("speciality_name")]
        public string Name { get; set; }
        [JsonPropertyName("speciality_code")]
        public string ExternalId { get; set; }
    }
}
