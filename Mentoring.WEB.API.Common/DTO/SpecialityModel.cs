using System.Collections.Generic;

namespace Mentoring.WEB.API.Common.DTO
{
    public class SpecialityModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<UniversityModel> Universities { get; set; }
    }
}