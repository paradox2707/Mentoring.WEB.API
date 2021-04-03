using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Models
{
    class EDBOUniversityModel
    {
        [JsonPropertyName("university_name")]
        public string UniversityName { get; set; }

        [JsonPropertyName("university_short_name")]
        public string UniversityShortName { get; set; }
    }
}
