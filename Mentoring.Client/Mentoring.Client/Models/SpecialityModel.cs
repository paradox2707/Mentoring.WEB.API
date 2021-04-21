using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mentoring.Client.Models
{
    public class SpecialityModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
<<<<<<< HEAD:Mentoring.Client/Mentoring.Client/Models/SpecialityModel.cs
=======

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("specialities")]
        public List<SpecialityModel> Specialities { get; set; }
>>>>>>> master:Mentoring.Client/Mentoring.Client/Models/UniversityModel.cs
    }
}
