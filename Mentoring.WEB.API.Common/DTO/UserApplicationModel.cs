using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common.DTO
{
    public class UserApplicationModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int PhoneNumber { get; set; }

        public int AverageMark { get; set; }

        public IEnumerable<RegionModel> Regions { get; set; }

        public IEnumerable<ProfessionalDirectionModel> ProfessionalDirections { get; set; }

        public UserApplicationModel()
        {
            Regions = new List<RegionModel>();

            ProfessionalDirections = new List<ProfessionalDirectionModel>();
        }
    }
}
