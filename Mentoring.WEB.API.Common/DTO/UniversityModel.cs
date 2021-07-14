using System.Collections.Generic;

namespace Mentoring.WEB.API.Common.DTO
{
    public class UniversityModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public decimal AverageMark { get; set; }

        public bool IsGoverment { get; set; }

        public string RegionName { get; set; }

        public List<SpecialityModel> Specialities{ get; set; }
    }
}
