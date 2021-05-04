using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mentoring.Client.Models
{
    public class ApplicationModel
    {
        public ApplicationModel()
        {
            Regions = new List<RegionModel>();

            ProfessionalDirections = new List<ProfessionalDirectionModel>();
        }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("secondName")]
        public string SecondName { get; set; }

        [JsonPropertyName("phoneNumber")]
        public int PhoneNumber { get; set; }

        [JsonPropertyName("averageMark")]
        public int AverageMark { get; set; }

        [JsonPropertyName("regions")]
        public List<RegionModel> Regions { get; set; }

        [JsonPropertyName("professionalDirections")]
        public List<ProfessionalDirectionModel> ProfessionalDirections { get; set; }
    }
}
