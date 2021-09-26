using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common
{
    public class ValidationError
    {
        [JsonPropertyName("RegionsAndProfessionalDirections")]
        public List<string> RegionsAndProfessionalDirections { get; set; }

        public ValidationError()
        {
            RegionsAndProfessionalDirections = new();
        }
    }
}
