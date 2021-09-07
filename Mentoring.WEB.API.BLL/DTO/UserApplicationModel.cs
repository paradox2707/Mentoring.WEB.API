using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.DTO
{
    public class UserApplicationModel
    {
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [RegularExpression("^\\d{9}$", ErrorMessage = "Please enter valid phone #, only 9 digits")]
        public int PhoneNumber { get; set; }

        [Range(100, 200, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
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
